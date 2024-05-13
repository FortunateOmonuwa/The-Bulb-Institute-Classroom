using System;

namespace areaoftriangle
{
    public class Program

    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter the value of base");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine(".................................");
            Console.WriteLine("please enter the value of height");
            int h = int.Parse(Console.ReadLine());
            Console.WriteLine(".................................");
            var solutionfortriangle = new Calculation();
            var result = solutionfortriangle.AreaOfTriangle(b, h);

            Console.WriteLine($" the result for area of triangle is : {result} ");


            Console.WriteLine("\n please enter the value of lenght");
            int l = int.Parse(Console.ReadLine());
            Console.WriteLine(".................................");
            Console.WriteLine("please enter the value of width");
            int w = int.Parse(Console.ReadLine());
            Console.WriteLine(".................................");

            var rectangle = new Calculation();
            rectangle.Rectangle(l, w);
            var result1 = rectangle.Rectangle(l, w);

            Console.WriteLine($" the result for area of rectangle is : {result1} ");


            Console.WriteLine("\n please enter the value of pi");
            double pi = double.Parse(Console.ReadLine());
            Console.WriteLine(".................................");
            Console.WriteLine("please enter the value of radius");
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine(".................................");

            var circumference = new Calculation();
            circumference.Circumference(pi, r);
            var result2 = circumference.Circumference(pi, r);

            Console.WriteLine($" the result for area of circumference is : {result2} ");



        }
    }
}
