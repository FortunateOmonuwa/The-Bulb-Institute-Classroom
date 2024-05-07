using System;
using System.Collections.Concurrent;

namespace ArrayOfString
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var ArrayOfString = new arr();

            //Get names in the array
            Console.WriteLine("Names in the Array");
            ArrayOfString.Getnames();
            Console.WriteLine("---------------------------------------");


            
            Console.WriteLine("Capitalized last character in the array");
            //Get last Capitalized character
            ArrayOfString.GetCapitalizeLAstCharacter();


            
            
        }

        

    }
}
