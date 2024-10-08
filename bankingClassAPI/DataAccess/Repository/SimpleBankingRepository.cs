using bankingClassAPI.DataAccess.Interface;
using bankingClassAPI.DataAccess.Utilities;
using bankingClassAPI.Model;
using bankingClassAPI.Model.DTOs;
using Microsoft.EntityFrameworkCore;

namespace bankingClassAPI.DataAccess.Repository
{
    public class SimpleBankingRepository : ISimpleBanking
    {
        private readonly ApplicationContext _ctx;
        public SimpleBankingRepository(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<User> CreateAccount(CreateAccoutDTO new_Acct)
        {
            try
            {
                var checkAcct = await _ctx.Users.AnyAsync(x => x.AccountNumber == new_Acct.AccountNumber);
                if (checkAcct)
                {
                    throw new Exception("Account number already exist");
                }
                var newAccount = new User()
                {
                    AccountName = new_Acct.AccountName,
                    Email = new_Acct.Email,
                    AccountNumber = GenerateRandomAccount.GetAcctNumber(),

                };
                await _ctx.Users.AddAsync(newAccount);
                await _ctx.SaveChangesAsync();
                return newAccount;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> DepositMoney(string acctNumber, decimal amount)
        {
            try
            {
                var account = await _ctx.Users.FirstOrDefaultAsync(x => x.AccountNumber == acctNumber);
                if(account == null)
                {
                    throw new Exception("Account number does not exist");
                }
                if(amount <= 0)
                {
                    throw new Exception("You cannot deposit zero or negative amount");
                }
                account.AccountBalance += amount;
                  _ctx.Users.Update(account);
                await _ctx.SaveChangesAsync();
                return account;



            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetAccoutBalanceDTO> GetAccountBalance(string acctNumber)
        {
            try
            {
                var checkAcct = await _ctx.Users.FirstOrDefaultAsync(x => x.AccountNumber == acctNumber);
                if(checkAcct == null)
                {
                    throw new Exception("Account number does not exist");
                }
                
                var AcctBalance = new GetAccoutBalanceDTO()
                {
                     AccountBalance = checkAcct.AccountBalance
                };
                return AcctBalance;


            }catch( Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> TransfeMoney(TransferMoneyToAnotherAcctDTO new_acct)
        {
            try
            {
                var sender = await _ctx.Users.FirstOrDefaultAsync(x => x.AccountNumber == new_acct.SenderAcct);
                var reciever = await _ctx.Users.FirstOrDefaultAsync(x => x.AccountNumber == new_acct.RecieverAcct);
                if (sender == null || reciever == null)
                {
                    throw new Exception("invalid acct for sender or recieve");
                }

                if(sender.AccountBalance < 100)
                {
                    throw new Exception("Your account balance is too low for this transaction");
                }
                if(new_acct.Amount <= 0)
                {
                    throw new Exception("You cannot transfer zero or negative amount");

                }
                sender.AccountBalance -= new_acct.Amount;
                reciever.AccountBalance += new_acct.Amount;
                _ctx.Users.Update(sender);
                _ctx.Users.Update(reciever);
                await _ctx.SaveChangesAsync();
                return $"Dear {sender.AccountNumber}, you have succefully transferred #{new_acct.Amount} to {reciever.AccountName}";

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> WithdrawMoney(WithdrawMoneyDTO new_acct)
        {
            var checkAcct = await _ctx.Users.FirstOrDefaultAsync(x => x.AccountNumber == new_acct.AccountNumber);
            if(checkAcct == null)
            {
                throw new Exception("Acct number does not exist");
            }
            if(new_acct.Amount <= 0)
            {
                throw new Exception("You cannot withdraw zero or negative balance");
            }
            checkAcct.AccountBalance -= new_acct.Amount;
            _ctx.Users.Update(checkAcct);
            await _ctx.SaveChangesAsync();
            return $"Dear {checkAcct.AccountName}, you have successfully withdraw {new_acct.Amount} from your account number {checkAcct.AccountNumber},your new balance is {checkAcct.AccountBalance}";
        }
    }
}
