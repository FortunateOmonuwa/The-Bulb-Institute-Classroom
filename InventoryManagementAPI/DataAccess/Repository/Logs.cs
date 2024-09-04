using InventoryManagementAPI.DataAccess.DataContext;
using InventoryManagementAPI.DataAccess.Interface;
using InventoryManagementAPI.Domain;
using InventoryManagementAPI.DTOs.Mail;
using InventoryManagementAPI.DTOs.Register_login;
using InventoryManagementAPI.Helper;
using InventoryManagementAPI.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryManagementAPI.DataAccess.Repository
{
    public class Logs : IRegister_Login
    {
        private readonly IEmailService _emailService;
        private readonly BaseSetup _setup;
        private readonly ApplicationContext _ctx;

        public Logs(IEmailService emailService, IOptions<BaseSetup> setup, ApplicationContext ctx)
        {
            _emailService = emailService;
            _setup = setup.Value;
            _ctx = ctx;
        }

        public async Task<ResponseModel<string>> Login(Login login)
        {
            var response = new ResponseModel<string>();
            try
            {
                var user = await _ctx.Users.Include(x=> x.Roles).ThenInclude(x=>x.Role).FirstOrDefaultAsync(x=>x.Email ==login.Email);
                var password = Utils.DecryptPassword(login.Password, user.PasswordHash);
                if(user == null || !password)
                {
                    response = response.FailedResult("Invalid email or password,pls try again");
                }else if (!user.Isverified)
                {
                    response = response.FailedResult("Account not verified,pls verify your account");
                }
                else
                {
                    var userRoles = user.Roles.Select(x=>x.Role.Name).ToList();
                    // Claims
                    var claims = new List<Claim>
                    {
                        new("Email",user.Email),
                        new("VerificationStatus", user.Isverified.ToString()),
                        
                   
                    };
                    foreach(var role in userRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role,role));
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_setup.SecretKey));
                    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _setup.Issuer,
                        signingCredentials: credentials,
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(120)
                        );
                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                    response = response.SuccessResult(jwtToken);
                }
                return response;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel<string>> RegenerateToken(string mail)
        {
            var response = new ResponseModel<string>();
            try
            {
                var user = await _ctx.Users.FirstOrDefaultAsync(x => x.Email == mail);

                if(user == null)
                {
                    response = response.FailedResult("User doest not exist,Pls try again");
                }else if (user.Isverified == true)
                {
                    response = response.FailedResult("Error, your Acct is verifified pls login");
                }else
                {
                    //VerificationToken = Utils.CreateRandomVerificationToken().Substring(0, 7),
                    //    VerifiedAt = "unverified",
                    //    TokenExpiration = DateTime.Now.AddMinutes(5).ToString(),

                    user.VerificationToken = Utils.CreateRandomVerificationToken().Substring(0, 7);
                    user.TokenExpiration = DateTime.Now.AddMinutes(5).ToString();
                    _ctx.Update(user);
                   var res = await _ctx.SaveChangesAsync();
                    if(res > 0)
                    {

                        var bodyMsg = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Email Verification</title>\r\n</head>\r\n<body style=\"margin: 0; padding: 0; font-family: Arial, sans-serif; background-color: #f4f4f4; color: #333;\">\r\n    <table align=\"center\" width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"max-width: 600px; margin: 0 auto; background-color: #ffffff; padding: 20px; border: 1px solid #ddd;\">\r\n        <tr>\r\n            <td align=\"center\" style=\"padding: 20px 0;\">\r\n                <h2 style=\"color: #333; margin: 0;\">Email Verification</h2>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td style=\"padding: 10px 20px; color: #555; font-size: 16px; line-height: 1.5; text-align: center;\">\r\n                <p>Thank you {user.FirstName} for signing up! Please use the OTP code below to verify your email address. This code will expire in 5 minutes : {DateTime.Now.AddMinutes(5).ToString("g")}.</p>\r\n                <p style=\"font-size: 18px; font-weight: bold; color: #007bff; margin: 20px 0; text-align: center;\">\r\n                    <span style=\"background-color: #f0f0f0; padding: 10px 20px; border: 1px solid #ddd; border-radius: 5px; display: inline-block;\">{user.VerificationToken}</span>\r\n                </p>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td style=\"padding: 20px 0; text-align: center; color: #777; font-size: 12px;\">\r\n                <p>If you did not request this, please ignore this email.</p>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n</html>\r\n";
                        var sendMail = new MailRequest
                        {
                            Reciever = user.Email,
                            Subject = "Regenerated Token: Verify Your Email",
                            Body = bodyMsg

                        };

                        await _emailService.SendEmailAsync(sendMail);
                        response = response.SuccessResult("Another verification token has been sent to your mail, pls verify your account");

                    }
                    else
                    {
                        response = response.FailedResult("Failed to regenerate token");
                    }


                }
                return response;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel<string>> RegisterAdmin(Register user)
        {
            var response = new ResponseModel<string>();
            try
            {
                var confirmIfEmailAlreadyExist = await _ctx.Users.AnyAsync(x => x.Email == user.Email);
                
                if (confirmIfEmailAlreadyExist)
                {
                    response = response.FailedResult("Email already exist, pls login");
                }else if (user.Password != user.ConfirmPassword)
                {
                    response = response.FailedResult("Password does not match,Pls try again");
                }
                else
                {

                    var newUser = new User
                    {   FirstName = user.FirstName,
                       LastName = user.LastName,
                        Email = user.Email,
                        PasswordHash = Utils.EncryptPassword(user.Password),
                        VerificationToken = Utils.CreateRandomVerificationToken().Substring(0, 7),
                        VerifiedAt = "unverified",
                        TokenExpiration = DateTime.Now.AddMinutes(5).ToString(),

                    };
                    await _ctx.Users.AddAsync(newUser);
                    var res = await _ctx.SaveChangesAsync();

                    //Update Admin Role to the registartion
                    var role = await _ctx.Roles.FirstOrDefaultAsync(x => x.Id == 1);
                    var userRole = new UserRole
                    {
                        RoleID = role.Id,
                        Role = role,
                        UserID = newUser.Id,
                        User = newUser,
                    };

                    newUser.Roles.Add(userRole);
                    await _ctx.SaveChangesAsync();
                    if (res > 0)
                    {
                        var bodyMsg = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Email Verification</title>\r\n</head>\r\n<body style=\"margin: 0; padding: 0; font-family: Arial, sans-serif; background-color: #f4f4f4; color: #333;\">\r\n    <table align=\"center\" width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"max-width: 600px; margin: 0 auto; background-color: #ffffff; padding: 20px; border: 1px solid #ddd;\">\r\n        <tr>\r\n            <td align=\"center\" style=\"padding: 20px 0;\">\r\n                <h2 style=\"color: #333; margin: 0;\">Email Verification</h2>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td style=\"padding: 10px 20px; color: #555; font-size: 16px; line-height: 1.5; text-align: center;\">\r\n                <p>Thank you {newUser.FirstName} for signing up! Please use the OTP code below to verify your email address. This code will expire in 5 minutes : {DateTime.Now.AddMinutes(5).ToString("g")}.</p>\r\n                <p style=\"font-size: 18px; font-weight: bold; color: #007bff; margin: 20px 0; text-align: center;\">\r\n                    <span style=\"background-color: #f0f0f0; padding: 10px 20px; border: 1px solid #ddd; border-radius: 5px; display: inline-block;\">{newUser.VerificationToken}</span>\r\n                </p>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td style=\"padding: 20px 0; text-align: center; color: #777; font-size: 12px;\">\r\n                <p>If you did not request this, please ignore this email.</p>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n</html>\r\n";
                        var sendMail = new MailRequest
                        {
                            Reciever = newUser.Email,
                            Subject = "Verify your email",
                            Body = bodyMsg
                        };
                        var mail = _emailService.SendEmailAsync(sendMail);
                        response = response.SuccessResult($"You have succefully created an account,Pls check your email to verify your account");
                    }
                    else
                    {
                        response = response.FailedResult("Error trying to save to database");
                    }
                }
                return response;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<ResponseModel<string>> RegisterStaff(Register user)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<string>> VerifyUser(string token)
        {
            var response = new ResponseModel<string>();
            try
            {
                var user = await _ctx.Users.FirstOrDefaultAsync(x => x.VerificationToken == token);
                if(user == null)
                {
                    response = response.FailedResult("Invalid token");
                }else if (DateTime.Now > DateTime.Parse(user.TokenExpiration))
                {
                    user.TokenExpiration = "";
                    user.VerificationToken = "";
                    user.VerifiedAt = "Unverified";
                    _ctx.Users.Update(user);
                    await _ctx.SaveChangesAsync();
                    response = response.FailedResult("Token Expired");
                }
                else
                {
                    user.Isverified = true;
                    user.VerificationToken = "";
                    user.VerifiedAt = DateTime.Now.ToString("G");
                    _ctx.Users.Update(user);
                    await _ctx.SaveChangesAsync();
                    response = response.SuccessResult("Verification Successful");
                
                }
                return response;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
