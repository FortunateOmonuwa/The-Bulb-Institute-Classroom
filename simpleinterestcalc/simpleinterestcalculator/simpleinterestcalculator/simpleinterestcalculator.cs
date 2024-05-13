using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace simpleintrestcalculator
{
    public class Investment
    {

        //properties
        //access modifier, data type and property name{get;set;} 
        public double Principal { get; set; }
        public double Rate { get; set; }
        public int Time { get; set; }


        //method
        //the access modifier, the data type and the method name()
        public double CalculateSimpleIntrest()
        {
            return (Principal * Rate * Time) / 100;
        }

        public double CalculateFinalAmount()
        {
            return Principal + CalculateSimpleIntrest();
        }
        public double CalculateInterestRate(double FinalAmount, double Principal)
        {
            return ((FinalAmount - Principal) / (Principal * Time)) * 100;
        }
        public int CalculateInvestmentDuration(double FinalAmount, double Principal, double Rate)
        {
            return (int)Math.Ceiling((FinalAmount - Principal) / (Principal * Rate)) * 100;
        }
    }

}