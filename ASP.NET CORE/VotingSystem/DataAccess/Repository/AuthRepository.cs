using Microsoft.EntityFrameworkCore;
using VotingSystem.DataAccess.DataContext;
using VotingSystem.DataAccess.Interfaces;
using VotingSystem.DataAccess.Utilities;
using VotingSystem.Domain.DTOs.LoginDTO;

namespace VotingSystem.DataAccess.Repository
{
    public class AuthRepository : IAuthService
    {
        private readonly VotingSystemContext database;
        public AuthRepository(VotingSystemContext database) 
        { 
            this.database = database;
        }
        public async Task<LoginResponse> Login(Login login)
        {
            LoginResponse response;
            try
            {

                var userlogin = await database
                    .UserProfiles
                    .FirstOrDefaultAsync(x => x.Email == login.Email);

                var passwordCheck = DataEncryption.DecryptPasswordUsingBcrypt(login.Password, userlogin.PasswordHash);

                if (userlogin != null && passwordCheck)
                {
                    response = new LoginResponse
                    {
                        _token = "no token for now",
                        _message = " Login successful",
                        _statusCode = 200
                    };
                }
                else
                {
                    response = new LoginResponse
                    {
                        _token = "no token for now",
                        _message = "Email or password is incorrect",
                        _statusCode = 400
                    };
                }
                //var password = DataEncryption.DecryptPasswordUsingBcrypt(login.Password, )

                return response;
            }
            catch (Exception ex)
            {
                response = new LoginResponse
                {
                    _token = "no token for now",
                    _message = ex.Message,
                    _statusCode = 400
                };
                return response;
            }
        }
    }
}
