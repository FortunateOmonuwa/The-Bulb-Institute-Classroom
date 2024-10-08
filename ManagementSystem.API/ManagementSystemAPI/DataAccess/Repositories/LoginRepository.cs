using ManagementSystemAPI.DataAccess.DataContext;
using ManagementSystemAPI.DataAccess.Helper;
using ManagementSystemAPI.DataAccess.Interfaces;
using ManagementSystemAPI.Domain.DTOS.LoginDTO;
using ManagementSystemAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ManagementSystemAPI.DataAccess.Repositories
{
    public class LoginRepository : ILogin
    {
        private readonly ApplicationContext _ctx;
        private readonly AppSetup _appSetup;
        public LoginRepository(ApplicationContext ctx, IOptions<AppSetup> appsetup)
        {
            _ctx = ctx;
            _appSetup = appsetup.Value;
        }
        public async Task<string> Login(Login login)
        {
            try
            {
                var user = await _ctx.Staffs.FirstOrDefaultAsync(x=>x.Email == login.Email);
                var confirmPassword = validator.DecryptPassword(login.Password, user.PasswordHash);
                if(user ==  null || !confirmPassword)
                {
                    throw new Exception("Invalid Email or Password, pls try again");
                }
                else
                {

                    user.IsLoggedIn = true;
                    user.IsClockedIn = true;
                    user.ClockIns = new List<Clockin> { new Clockin(){

                        StaffID = user.ID

                    } };
                    _ctx.Staffs.Update(user);
                    var res = await _ctx.SaveChangesAsync();

                    if (res > 0)
                    {

                    
                    //Claims
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Email, login.Email),
                        
                    };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSetup.SecretKey));
                        var signingCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            _appSetup.Issuer,
                            signingCredentials : signingCredentials,
                            claims : claims,
                            expires : DateTime.Now.AddMinutes(60)
                            );

                        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                        return $"You Login is sucessfull.\n JwtToken = ${jwtToken}";

                    }
                    else
                    {
                        throw new Exception("Unable to save to database");
                    }
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> Logout(string email)
        {
            try
            {
                var user = await _ctx.Staffs.FirstOrDefaultAsync(x => x.Email == email);
                if (user == null)
                {
                    throw new Exception("Email does not exist");
                }else if (user.IsLoggedIn == false )
                {
                    throw new Exception("Sorry,you are not logged in");
                }
                else
                {
                    user.IsLoggedIn = false;
                    user.IsClockedIn = false;
                    user.ClockOuts = new List<ClockOut> { new ClockOut(){

                        StaffID = user.ID

                    } };
                    _ctx.Staffs.Update(user);
                    var res = await _ctx.SaveChangesAsync();

                    return "You have logged out sucessfully";
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
