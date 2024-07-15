using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberValidator.Model
{
    public static  class NumberValidator
    {
        public static string PhoneValidator(string phoneNumber)
        {
            var starter = "+234";
            if(!phoneNumber.StartsWith(starter))
            {
                return "Phone number must start with +234";
            }
            var numberAfter = phoneNumber.Substring(4);
            if(numberAfter.Length > 10)
            {
                return "Invalid: didgit after +234 must not be greater than 10 ";
            }
           
            foreach(char c in numberAfter)
            {
                if (!char.IsDigit(c))
                {
                    return "Invalid format, input must be a number after +234";
                }
            }
            return "Correct number format";
        }
    }
}
