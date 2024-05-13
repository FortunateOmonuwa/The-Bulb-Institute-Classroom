using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class7.Utilities
{
    internal static class UserValidator 
    {
        public static string GetValidInput(string specificInput)
        {
            string input;
            do
            {
                Console.Write($"Please enter a valid {specificInput}: ");
                input = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(input) || input.Length < 4);
            return input;
        }

        public static string GetValidPhoneNumber()
        {
            string input;
            do
            {
                Console.Write($"Enter your phonenumber (Must be 11 digits): ");
                input = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(input) || input.Length < 11);
            return input;
        }
        public static string GetValidPassword()
        {
            string input;
            do
            {
                Console.Write($"Enter your password (Must be at least 8 digits): ");
                input = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(input) || input.Length < 8);
            return input;
        }

        public static string GetGender()
        {
            string gender;
            do
            {
                Console.Write("Please enter a valid gender (Male/Female): ");
                gender = Console.ReadLine().Trim().ToLower();
            } while (gender != "male" && gender != "female");
            return gender;
        }
    }
}
