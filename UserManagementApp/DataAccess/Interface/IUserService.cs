using UserManagementApp.Domain.DTO;
using UserManagementApp.Domain.Model;

namespace UserManagementApp.DataAccess.Interface
{
    public interface IUserService
    {
        Task<User> RegisterUser(RegisterDTO newUser);
        Task<string> LoginUser(LoginDTO userLogin);
    }
}
