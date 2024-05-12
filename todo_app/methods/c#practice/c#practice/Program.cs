// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Cryptography.X509Certificates;
namespace Practices
{
    class Multiplication
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("enter your multiplier ");
            // number = int.Parse(Console.ReadLine());
            int number = 1;
            while(number <= 10)
            {
                Console.WriteLine($" 3 x {number} = {3 * number} ");
                number++;
            }
        }
    }   
 }           


