using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class7.Utilities
{
    internal class Startup
    {
        public static int StartupMethod()
        {
            Console.Write($"Enter 1 to add a user or \n2. to exit the program : ");
            int input = int.Parse(Console.ReadLine());
            return input;

        
        }
    }
}
