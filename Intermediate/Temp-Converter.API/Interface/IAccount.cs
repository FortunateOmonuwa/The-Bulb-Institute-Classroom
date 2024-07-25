using Temp_Converter.API.DTO;

namespace Temp_Converter.API.Interface
{
    public interface IAccount
    {
        Task<string> CreateAccount(AccountCreationDTO newAccount);
        
        
    }
}
