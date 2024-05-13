using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssementOne
{
  
    public static class StaticClassTest
    {


        public static void SeeSomeThing()
        {
            Console.WriteLine("I have seen something");
            Class1 test = new Class1(); 
        }

        public static void SeeSomeThing(string name)
        {
            Console.WriteLine($"Your name is {name}");
        }
        public static void SeeSomeThing(int age)
        {
            Console.WriteLine(age);
        }
    }
}
