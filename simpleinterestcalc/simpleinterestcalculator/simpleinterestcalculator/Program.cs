using System;
using System.Threading;

namespace simpleintrestcalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var Investment = new Investment();
            Console.WriteLine("Enter the principal amount:");
            var UserPrincipalAmount = Console.ReadLine();

            Console.WriteLine("Enter the intrest rate:");
            var UserInterestRate = Console.ReadLine();

            Console.WriteLine("Enter the investment duration (in years):");
            var UserInvestmentDuration = Console.ReadLine();

            Investment.Principal = Double.Parse(UserPrincipalAmount);
            Investment.Rate = Double.Parse(UserInterestRate);
            Investment.Time = int.Parse(UserInvestmentDuration);


            double SimpleIntrestResult = Investment.CalculateSimpleIntrest();
            Console.WriteLine(SimpleIntrestResult);

            double FinalAmountResult = Investment.CalculateFinalAmount();
            Console.WriteLine(FinalAmountResult);

            double IntrestRateResult = Investment.CalculateInterestRate(FinalAmountResult, double.Parse(UserPrincipalAmount));
            Console.WriteLine(IntrestRateResult);

            int InvestmentDuration = Investment.CalculateInvestmentDuration(FinalAmountResult, int.Parse(UserInvestmentDuration), double.Parse(UserInvestmentDuration));
            Console.WriteLine(InvestmentDuration);



        }
    }


}