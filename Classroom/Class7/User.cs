using Class7.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class7
{
    internal class User
    {
        public User(string name, string email, string password, string phoneNumber, string address, string gender)
        {
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Address = address;
            Gender = gender;
        }
       
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        public static User AddUser()
        {
           
            Console.WriteLine($"Enter details for User:");
            string name = UserValidator.GetValidInput("Name");
            string email = UserValidator.GetValidInput("Email");
            string password = UserValidator.GetValidPassword();
            string phoneNumber = UserValidator.GetValidPhoneNumber();
            string address = UserValidator.GetValidInput("Address");
            string gender = UserValidator.GetGender();

            User newUser = new User(name, email, password, phoneNumber, address, gender);

           //// users[0] = newUser;
           // foreach ( var user in users )
           // {
           //     Console.WriteLine(user.Name);
           // }

            return newUser;
        }

    }
}
