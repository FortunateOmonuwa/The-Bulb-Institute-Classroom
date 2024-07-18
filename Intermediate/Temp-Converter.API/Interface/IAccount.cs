using Temp_Converter.API.DTO;

namespace Temp_Converter.API.Interface
{
    public interface IAccount
    {
        Account CreateAccount(AccountCreationDTO newAccount);
        
        
    }
}
