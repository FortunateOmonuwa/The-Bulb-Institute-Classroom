using System;
using System.Security.Cryptography.X509Certificates;

namespace SimpleInterestCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Create an Instace of the investment class
            Investments firstInvestment = new Investments();



            Console.WriteLine("Enter 1 to calculate simple interest \n2 to calculate final amount \n3 to calculate investment rate");

            var userEntry = int.Parse(Console.ReadLine()); //Converting the string into an integer
            switch (userEntry)
            {
                case < 1:
                Console.WriteLine("You can't enter a value less than 1");
                break;
                case  2:
                ReturnInterest();
                break;
                case 3:
                Console.WriteLine("You're trying to calculate the investment rate");
                break;
                default:
                Console
                .WriteLine("You entered the wrong number");
                break;

            }
            //if (userEntry < 1)
            //{
            //    Console.WriteLine("You can't enter a value less than 1");
            //}
            //else if (userEntry == 1)
            //{
            //    ReturnInterest();

            //}
            //else if(userEntry == 2)
            //{
            //    Console.WriteLine("You're trying to calculate the final amount");
            //}
            //else if( userEntry == 3)
            //{
              
            //    Console.WriteLine("You're trying to calculate the investment rate");
            
            //}
            //else
            //{
            //    Console
            //        .WriteLine("You entered the wrong number");
            //}


             void ReturnInterest()
            {
                Console.WriteLine("Pls enter your principal amount");
                double principal = double.Parse(Console.ReadLine());
                Console.WriteLine("Pls enter your interest rate");
                double interestRate = double.Parse(Console.ReadLine());

                Console.WriteLine("Pls enter your duration");
                int investmentDuration = int.Parse(Console.ReadLine());

                firstInvestment.Principal = principal;
                firstInvestment.Rate = interestRate;
                firstInvestment.Time = investmentDuration;

                var simpleInterest = firstInvestment.CalculateSimpleInterest();
                Console.WriteLine(simpleInterest);
            }

            ////Prompt the user to enter the principal amount,interest rate and investment duration(in years)
            //Console.WriteLine("Welcome to your Simple Interest Calculator");
            //Console.WriteLine("-----------------------------------------");
            //Console.WriteLine("Pls enter your name");
            //string name = Console.ReadLine();



            //Console.WriteLine("Pls enter your principal amount");
            //double userPrincipalAmount = double.Parse(Console.ReadLine());


            //Console.WriteLine("Pls enter your interest rate");
            //double userInterestRate = double.Parse(Console.ReadLine());

            //Console.WriteLine("Pls enter your duration");
            //int userInvestmentDuration = int.Parse(Console.ReadLine());

            ////Assigning User Inputs to Field.
            //firstInvestment.Principal = userPrincipalAmount;
            //firstInvestment.Rate = userInterestRate;
            //firstInvestment.Time = userInvestmentDuration;


            ////Call the respective methods to calculate
            ////the simple interest,
            ////final amount,
            ////interest rate (based on the final amount),
            ////and investment duration (based on the final amount).

            ////(a) Calculating Simple Interest
            //double simpleInterestResult=firstInvestment.CalculateSimpleInterest();
            ////(b) calculating final Amount
            //double finalAmountResult = firstInvestment.CalculateFinalAmount();
            ////(c) calculating interest rate
            //double interestRateResult = firstInvestment.CalculateIntrestRate( finalAmountResult , userPrincipalAmount);
            ////(d) calculating investment duration
            //int investmentDurationResult = firstInvestment.CalculateInvestmentDuration( finalAmountResult, (int)userPrincipalAmount, userInterestRate);

            //Console.WriteLine($"Your inputed data are Principal :{userPrincipalAmount}.\n Rate: {userInterestRate}.\n Time :{userInvestmentDuration}years");
            //Console.WriteLine("-----------------------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------------------");
            //Console.WriteLine("Calculating Based on your Data");
            //Console.WriteLine($"Welcome{name}\n Simple Interest: {simpleInterestResult}.\n Final-Amount: {finalAmountResult}.\n Interest Rate: {interestRateResult}.\n Investment-Duration: {investmentDurationResult}");



        }
  
    }
}
