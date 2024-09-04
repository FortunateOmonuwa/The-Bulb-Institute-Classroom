using InventoryManagementAPI.DTOs.Register_login;
using InventoryManagementAPI.Helper;

namespace InventoryManagementAPI.DataAccess.Interface
{
    public interface IRegister_Login
    {
        Task<ResponseModel<string>> RegisterAdmin(Register user);
        Task<ResponseModel<string>> RegisterStaff(Register user);
        Task<ResponseModel<string>> VerifyUser(string token);
        Task<ResponseModel<string>> Login(Login login);
        Task<ResponseModel<string>> RegenerateToken(string mail);

    }
}
