using UserManagementApi.Domain;
using UserManagementApi.DTOS;
using UserManagementApi.Utilities;

namespace UserManagementApi.DataAccess.Interface
{
    public interface IUserService
    {
        Task<ResponseModel<User>> RegisterUser(Register new_user);
        Task<ResponseModel<string>> VerifyUser(string token);

        public Task<ResponseModel<string>> Login(Login login);
    }
}
