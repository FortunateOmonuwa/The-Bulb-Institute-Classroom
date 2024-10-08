using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace bankingClassAPI.Model.DTOs
{
    public class TransferMoneyToAnotherAcctDTO
    {
        public string SenderAcct { get; set; }

        public string RecieverAcct { get; set; }

        public decimal Amount { get; set; }
    }
}
