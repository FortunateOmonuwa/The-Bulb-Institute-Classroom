// See https://aka.ms/new-console-template for more information
using System;
using user_array;
namespace array
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            Console.WriteLine("enter your name /n your name should not be less than 4 ");
            string name = Console.ReadLine();

            Console.WriteLine("enter your email ");
            string email = Console.ReadLine();

            Console.WriteLine("enter your password /n password must not be less than 8 letters ");
            string password = Console.ReadLine();

            Console.WriteLine("enter your phone number ");
            string phone_number = Console.ReadLine();

            Console.WriteLine("enter your address ");
            string address = Console.ReadLine();

            Console.WriteLine("enter your gender ");
            string gender = Console.ReadLine();

            var validation = Validation.UserValidation(name,password,gender, phone_number);
            if (!validation.Item1)
            {
                Console.WriteLine(validation.Item2);
            }
            else
            {
                var createuser = UserCreation.AddUser(name, email, password, phone_number, address, gender);
                Console.WriteLine(createuser);
            }


            Console.ReadKey();
        }
        
    }
}
