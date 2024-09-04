
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement.API.DataAccess.DataContext;
using UserManagement.API.DataAccess.Interfaces;
using UserManagement.API.Domain;
using UserManagement.API.DTOs;
using UserManagement.API.Service;
using UserManagement.API.Utilities;

namespace UserManagement.API.DataAccess.Repositories
{
    public class UserRepository : IUserService
    {
        private readonly  IMailService mailService;
        private readonly UserContext context;
        private readonly AppSettings appSettings;
        private readonly IMemoryCache cache;
        public UserRepository(IMailService mailService, UserContext context, IOptions<AppSettings> appSettings, IMemoryCache cache)
        {
            this.mailService = mailService;
            this.context = context;
            this.appSettings = appSettings.Value;
            this.cache = cache;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var userCacheKey = "AllUsers";
            var userCache = cache.TryGetValue(userCacheKey, out  List<User> users);
            if(userCache == false)
            {
                users = await context.Users.ToListAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20),
                    SlidingExpiration = TimeSpan.FromMinutes(7),
                };

                cache.Set(userCacheKey, users, cacheEntryOptions);
            }

            return users;
        }
       
        public async Task<User> GetAllUsers(int id)
        {
            var users = await GetAllUsers();
            var user = users.Where(x => x.Id == id).FirstOrDefault();
            return user;
        }

        public async Task<ResponseModel<string>> Login(Login login)
        {
            try
            {
                var response = new ResponseModel<string>();
                var user = await context.Users
                    .Include(x => x.Roles)
                    .ThenInclude(x => x.Role)
                    .FirstOrDefaultAsync(X => X.Email == login.Email);
                var confirmPassword = Helper.VerifyPasswordHash(login.Password, user.PasswordHash, user.PasswordSalt);
                if (user == null || !confirmPassword)
                {
                    response = response.FailedResultData("Email or Password is incorrect");
                }
                else if (!user.IsVerified)
                {
                    response = response.FailedResultData("Account not verified... Please verify your account");
                }
                else
                {
                    var userRoles = user.Roles.Select(x => x.Role.Name).ToList();
                    //claims 
                    var claims = new List<Claim>
                    {
                        new (ClaimTypes.Email, user.Email),
                      //  new("VerificationStatus", user.IsVerified ? "Verified" : "Unverified"),
                    };

                    foreach (var role in userRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.SecretKey));
                    var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                            appSettings.Issuer,
                            signingCredentials: signingCredentials,
                            claims: claims,
                            expires: DateTime.Now.AddMinutes(60)

                        );

                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                    response = response.SuccessResultData(jwtToken);

                }
                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<ResponseModel<User>> Register(Register new_user)
        {
            var response = new ResponseModel<User>();

            try
            {
                if(new_user.Password != new_user.ConfirmPassword)
                {
                    throw new Exception("Passwords do not match");
                }
                Helper.CreatePasswordHash(new_user.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var user = new User
                {
                    Email = new_user.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    VerificationToken = Helper.CreateRandomVerificationToken().Substring(0, 7),
                    TokenExpiration = DateTime.Now.AddMinutes(1).ToString(),
                    VerifiedAt = "Unverified"
                };

                await context.Users.AddAsync(user);
                var res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    var regMail = new MailRequest
                    {
                        Receiver = user.Email,
                        Subject = "Verify Your Email",
                        Body = user.VerificationToken
                    };
                    var mail = mailService.SendMail(regMail);
                   response = response.SuccessResultData(user);
                }
                else
                {
                   response= response.FailedResultData(user);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return response;
        }
        public async Task<ResponseModel<string>> VerifyAccount(string token)
        {
            var response = new ResponseModel<string>();
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.VerificationToken == token);
                if (user == null)
                {
                 response = response.FailedResultData("Invalid token");
                  
                }
                else if (DateTime.Now > DateTime.Parse( user.TokenExpiration))
                {
                    user.TokenExpiration = "";
                    user.VerificationToken = "";
                    user.VerifiedAt = "Unverified";
                    context.Users.Update(user);
                    await context.SaveChangesAsync();
                    response = response.FailedResultData("Token expired");
                }
                else
                {
                    user.IsVerified = true;
                    user.TokenExpiration = "";
                    user.VerificationToken = "";
                    user.VerifiedAt = DateTime.Now.ToString();
                    context.Users.Update(user);

                    var role = await context.Roles.FirstOrDefaultAsync(x => x.Id == 1);
                    var userRole = new UserRole
                    {
                        RoleID = role.Id,
                        Role = role,
                        UserID = user.Id,
                        User = user
                    };
                    user.Roles.Add(userRole);
                    await context.SaveChangesAsync();
                    response = response.SuccessResultData("Verification Successful");

                    
                }
               
                
            }
            catch (Exception ex)
            {
                
                throw;
            }
            return response;
        }
    }
}
