using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_array
{
    public class Validation
    {
        public static (bool, string) UserValidation(string name, string password, string gender, string phonenumber)
        {
            if (name.Length < 4)
            {
                return (false, "name must be more than 4 letters");
            }
            else if (password.Length < 8)
            {
                return (false, "the password cannot be less than 8 letters");
            }
            else if (gender != "male" && gender != "female")
            {
                return (false, "gender must be male or female");
            }
            else if (phonenumber.Length != 11)
            {
                return (false, "enter eleven digit phone number ");
            }
            else
            {
                return (true, "exit");
            }
        }

}
}


