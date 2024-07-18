using Temp_Converter.API.DTO;
using Temp_Converter.API.Interface;

namespace Temp_Converter.API.Repository
{
    public class AccountRepository : IAccount
    {
      
        public Account CreateAccount(AccountCreationDTO newAccount)
        {
            try
            {
                var new_account = new Account()
                {
                    Id = new Guid(),
                    AccountNumber = newAccount.AccountNumber,
                    Email = newAccount.Email,
                    Name = newAccount.Name
                };

                return new_account;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
