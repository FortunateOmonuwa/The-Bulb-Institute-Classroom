using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithCollections
{
    internal class Student
    {

        public bool LoginStatus;

        List<Staff> staff2 = new List<Staff>()
        {
            new Staff(){StaffID = 1, StaffName = " Afeez" , Email = "Abc@gmail.com", Password="Akanbi"},
            new Staff(){StaffID = 2, StaffName = " Kazeem", Email = "Abb@gmail.com", Password="Akanbi"},
            new Staff(){StaffID = 3, StaffName = " Akanbi", Email = "Aba@gmail.com", Password="Akanbi"},
        };

        public string GetStaff(int ID)
        {
            var person = staff2.FirstOrDefault(x => x.StaffID == ID);//null or empty

            if (person == null)
            {
                return "Person doesn't exist";
            }
            else
            {
                return $"{person.StaffID}\n{person.StaffName}";
            }
        }

        public string Login(string staffnameoremail, string password)
        {

            var confirmStaff = ConfirmStaff(staffnameoremail, password);

            if (confirmStaff != null)
            {
                
                return $"Log in successful";
            }
            else
            {
                return "You do not exist";
            }

        }

        private Staff ConfirmStaff(string staffnameoremail, string password)
        {
            var confirmStaff = staff2.
                FirstOrDefault(x => (x.StaffName.ToLower().Trim() == staffnameoremail.ToLower().Trim())
                || (x.Email.ToLower().Trim() == staffnameoremail.ToLower().Trim())
                && (x.Password.ToLower().Trim() == password.ToLower().Trim()));

            return confirmStaff;
        }

    }
}
