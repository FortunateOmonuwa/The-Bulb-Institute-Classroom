using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOfInteger.Ak.models
{
    public class utilities
    {
        int[] ArrOfInt = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,13,17,19,22,33,53};

        int sum = 0;
        int evenCounter;
        int oddCounter;
        public void GetEvenDetails()
        {
            foreach (int num in ArrOfInt)
            {
                if(num % 2 == 0)
                {
                    sum += num;
                    evenCounter++;
                }
            }
                    Console.WriteLine($"The total sum of Even numbers is {sum}\nLength of Even Number {evenCounter}" );

        }

        public void GetOddDetails()
        {
            foreach (int num in ArrOfInt)
            {
                if (num % 2 == 1)
                {
                    sum += num;
                    oddCounter++;
                }
            }
            Console.WriteLine($"The total sum of Odd numbers is {sum}\nLength of Odd Number {oddCounter}");

        }
    }
}
