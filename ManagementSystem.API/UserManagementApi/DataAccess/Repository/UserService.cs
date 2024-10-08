using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagementApi.DataAccess.DataContext;
using UserManagementApi.DataAccess.Interface;
using UserManagementApi.Domain;
using UserManagementApi.DTOS;
using UserManagementApi.Service;
using UserManagementApi.Utilities;

namespace UserManagementApi.DataAccess.Repository
{
    public class UserService(UserContext ctx, IEmailService emailService, IOptions<AppSettings> appSettings) : IUserService
    {
        private readonly AppSettings _appSettings = appSettings.Value;

        public async Task<ResponseModel<string>> Login(Login login)
        {
            var response = new ResponseModel<string>();

            try
            {

            var user = await ctx.Users.Include(x => x.Roles).ThenInclude(x=> x.Role).FirstOrDefaultAsync(x => x.Email == login.Email);
            var confirmPassword = Helper.VerifyPasswordHAsh(login.Password,user.PasswordHash,user.PasswordSalt);
            if(user == null || !confirmPassword)
            {
                response = response.FailedResultData("Invalid Email or Password");
            }else if (!user.Isverified)
                {
                    response = response.FailedResultData("Account not verified pls verify account,pls verify your account");
                }
                else
                {
                    var userRoles = user.Roles.Select(x => x.Role.Name).ToList();
                    //Claims
                    var claims = new List<Claim>
                    {
                        new (ClaimTypes.Email,user.Email),
                        new("VerificationStatus",user.Isverified.ToString())
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.SecretKey));
                    var signingCredentials = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        _appSettings.Issuer,
                        signingCredentials : signingCredentials,    
                        claims : claims,
                        expires : DateTime.Now.AddMinutes(60)
                        );

                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                    response = response.SuccessResultData(jwtToken);
                }
                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseModel<User>> RegisterUser(Register new_user)
        { 
            
            var response = new ResponseModel<User>();   
          
            try
            {
                Helper.CreatePasswordHash(new_user.Password, out byte[]passwordHash,out byte[]passwordSalt);
                var user = new User
                {
                    Email = new_user.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    VerificationToken = Helper.CreateRandomVeificationToken().Substring(0, 7),
                    TokenExpiration = DateTime.Now.AddMinutes(1).ToString(),
                    VerifiedAt = "univerified"
                    
                };

                await ctx.Users.AddAsync(user);
                var res = await ctx.SaveChangesAsync();
                if(res > 0)
                {
                    var sdMail = new MailRequest
                    {
                     Reciever = user.Email,
                     Subject = "Verify your email",
                     Body = user.VerificationToken
                    };
                    var mail = emailService.SendMail(sdMail);
                    response = response.SuccessResultData(user);
                }
                else
                {
                   response = response.FailedResultData(user);
                }
                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseModel<string>> VerifyUser(string token)
        { 
            var response = new ResponseModel<string>(); 

            try
            {
                var user = await ctx.Users.FirstOrDefaultAsync(x => x.VerificationToken == token);
                if(user == null)
                {
                    response = response.FailedResultData("Invalid Token");
                }else if(DateTime.Now > DateTime.Parse(user.TokenExpiration))
                {
                    user.TokenExpiration = "";
                    user.VerificationToken = "";
                    user.VerifiedAt = "Unverified";
                    ctx.Users.Update(user);
                    await ctx.SaveChangesAsync();
                    response = response.FailedResultData("Token Expired");
                }
                else
                {
                    user.Isverified = true;
                    user.TokenExpiration = "";
                    user.VerificationToken = "";
                    user.VerifiedAt = DateTime.Now.ToString();
                    ctx.Users.Update(user);

                    var role = await ctx.Roles.FirstOrDefaultAsync(x => x.Id == 1);
                    var userRole = new UserRole
                    {
                        RoleID = role.Id,
                        Role = role,
                        UserID = user.Id,
                        User = user

                    };
                    user.Roles.Add(userRole);
                    await ctx.SaveChangesAsync();
                    response = response.SuccessResultData("Verification Successful");


                }
            }
            
            catch
            {
                throw;
            }
            return response;
        }
    }
}
