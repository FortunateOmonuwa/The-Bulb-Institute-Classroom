
using Microsoft.EntityFrameworkCore;
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
        public UserRepository(IMailService mailService, UserContext context)
        {
            this.mailService = mailService;
            this.context = context;
        }
        public async Task<ResponseModel<User>> Register(Register new_user)
        {
            var response = new ResponseModel<User>();

            try
            {
                Utility.CreatePasswordHash(new_user.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var user = new User
                {
                    Email = new_user.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    VerificationToken = Utility.CreateRandomVerificationToken().Substring(0, 7),
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
                 response =   response.FailedResultData("Invalid token");
                  
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
