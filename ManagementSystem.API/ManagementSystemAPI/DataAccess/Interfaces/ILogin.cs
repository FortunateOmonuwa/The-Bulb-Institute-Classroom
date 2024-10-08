using ManagementSystemAPI.Domain.DTOS.LoginDTO;

namespace ManagementSystemAPI.DataAccess.Interfaces
{
    public interface ILogin
    {
        Task<string> Login(Login login);
        Task<string> Logout(string email);
        
    }
}
