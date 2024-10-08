using bankingClassAPI.Model;
using bankingClassAPI.Model.DTOs;

namespace bankingClassAPI.DataAccess.Interface
{
    public interface ISimpleBanking
    {
        Task<User> CreateAccount(CreateAccoutDTO new_Acct);
        Task<User> DepositMoney(string acctNumber,decimal amount);
        Task<GetAccoutBalanceDTO> GetAccountBalance (string acctNumber);

        Task<string> TransfeMoney(TransferMoneyToAnotherAcctDTO new_acct);
        Task<string> WithdrawMoney(WithdrawMoneyDTO new_acct);

    }
}
