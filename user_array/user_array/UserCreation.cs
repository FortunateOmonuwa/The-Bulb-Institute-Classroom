using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_array
{
    public class UserCreation
    {
        public static string AddUser(string name,string email,string password, string phoneNumber,string address,string gender)
        {
            List<Userclass> users = new List<Userclass>();
            var user = new Userclass();
            user.Name = name;
            user.Email = email; 
            user.Password = password;   
            user.PhoneNumber = phoneNumber;
            user.Address = address;
            user.Gender = gender;
            users.Add(user);

            return "new user added";


        }
    }
}
