using ArrayOfInteger.Ak.models;
using System;

namespace ArrayOfInteger.Ak
{
    public class Program
    { 
        static void Main(string[] args)
        {
            //int[] ArrayOfInt = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };

            var program = new utilities();

            Console.WriteLine("--------------Even number Details--------------------");
            program.GetEvenDetails();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");


            Console.WriteLine("--------------Odd number Details--------------------");
            program.GetOddDetails();

        }
    }
}
