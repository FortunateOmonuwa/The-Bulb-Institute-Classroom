using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staffmgt
{
    public class Staffname
    {
        public string StaffName {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Hiredate { get; set; }
        public int StaffNumber { get; set; }
        public bool IsClockedIn { get; set; }
        public string IsActive { get; set; }
        public string IsLoggedIn { get; set; }

        //method

        public void Details(string StaffName, string Email, string Password, DateTime Hiredate, int StaffNumber, bool IsClockedIn, string IsActive, string IsLoggedIn)
       
        {
            Console.WriteLine("enter your name :");
            string staffname = Console.ReadLine();

            Console.WriteLine("enter your Email :");
            string email = Console.ReadLine();

            Console.WriteLine("enter your password :");
            string password = Console.ReadLine();

            Console.WriteLine("enter your date of hiring :");
            DateTime hirinngDate = DateTime.Now;

            Console.WriteLine("enter your staff number :");
            string staffnumber = Console.ReadLine();

            Console.WriteLine("indicate if staff memeber clock's in :");
            bool clockedin = true;

            Console.WriteLine("enter your is active :");
            bool isactive = true;

            Console.WriteLine("indicate login :");
            bool login = true;

           

        }

    }

}
