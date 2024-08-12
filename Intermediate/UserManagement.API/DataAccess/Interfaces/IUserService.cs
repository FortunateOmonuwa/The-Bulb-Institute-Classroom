using UserManagement.API.Domain;
using UserManagement.API.DTOs;
using UserManagement.API.Utilities;

namespace UserManagement.API.DataAccess.Interfaces
{
    public interface IUserService
    {
        Task<ResponseModel<User>> Register(Register new_user);
        Task<ResponseModel<string>> VerifyAccount(string token);
        Task<ResponseModel<string>> Login(Login login);
    }
}
