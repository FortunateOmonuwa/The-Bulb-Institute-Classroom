using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SimpleInterestCalculator
{
   
    public class Investments
    {
        //Properties
        public double Principal {  get; set; }
        public double Rate { get; set; }
        public int Time {  get; set; }

        //Method for Calculating Simple Interest
        public double CalculateSimpleInterest()
        {
            return (Principal * Rate * Time)/100;
        }

        //Method for Calculating Final Amount

        public double CalculateFinalAmount()
        {
            return Principal + CalculateSimpleInterest(); 
        }

        //Method for Calculating Interest Rate
        public double CalculateIntrestRate(double finalAmount, double principal)
        {
            return ((finalAmount - principal) / (principal * Time)) * 100;
        }
        //Method for calculating duration
        public int CalculateInvestmentDuration(double finalAmount, int principal,double rate)
        {
            return (int)((finalAmount - principal) / (principal * rate) * 100);
        }

    }
}
