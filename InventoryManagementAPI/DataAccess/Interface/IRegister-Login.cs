using InventoryManagementAPI.Domain;
using InventoryManagementAPI.DTOs.Register_login;
using InventoryManagementAPI.Helper;

namespace InventoryManagementAPI.DataAccess.Interface
{
    public interface IRegister_Login
    {
        Task<ResponseModel<string>> RegisterAdmin(Register user);
        Task<ResponseModel<string>> RegisterStaff(Register user);
        Task<ResponseModel<string>> RegisterCustumer(Register user);
        Task<ResponseModel<string>> VerifyUser(string token);
        Task<ResponseModel<string>> Login(Login login);
        Task<ResponseModel<string>> RegenerateToken(string mail);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByID(Guid id );
        Task<ResponseModel<string>> DeleteUser(Guid id);
        

    }
}
