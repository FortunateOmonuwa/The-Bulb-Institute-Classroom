using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UserManagementApp.DataAccess.DataContext;
using UserManagementApp.DataAccess.Helper;
using UserManagementApp.DataAccess.Interface;
using UserManagementApp.Domain.DTO;
using UserManagementApp.Domain.Model;

namespace UserManagementApp.DataAccess.Repository
{
    public class UserRepository : IUserService
    {
        private readonly UserContext _ctx;
        public UserRepository(UserContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<string> LoginUser(LoginDTO userLogin)
        {
            try
            {
                var user = await _ctx.Users.FirstOrDefaultAsync(x=>x.Email == userLogin.Email);
                if (user == null)
                {
                    throw new Exception("User Information is invalid");
                }
                var response = Utilities.DecrytPassword(userLogin.Password, user.Password);
                if (response)
                {
                return "Login Successfull";

                }
                else
                {
                    return "Invalid password";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> RegisterUser(RegisterDTO newUser)
        {
            try
            {
            var user = await _ctx.Users.AnyAsync(x => x.Email == newUser.Email);
                if (user)
                {
                    throw new Exception("Email already exist");
                }
                var registerNewUser = new User()
                {
                    Email = newUser.Email,
                    Password = Utilities.EncryptPassword(newUser.Password),
                    UserName = Utilities.GenerateUsername(newUser.Email)
                };
                await _ctx.Users.AddAsync(registerNewUser);
                await _ctx.SaveChangesAsync();
                return registerNewUser;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            
        }
    }
}
