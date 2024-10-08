namespace bankingClassAPI.DataAccess.Utilities
{
    public class GenerateRandomAccount
    {
        public static string GetAcctNumber()
        {
            Random random = new Random();
            string acctNumberDigits = "";
            for(int i = 0; i < 10; i++)
            {
                acctNumberDigits += random.Next(0,10).ToString();
            }
            return acctNumberDigits;
        }
    }
}
