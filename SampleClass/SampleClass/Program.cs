using System;
using System.Collections.Generic;
using System.Net.Security;

namespace SampleClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter a number: ");
            //int input = int.Parse(Console.ReadLine());
            //Console.Write("Enter a number: ");
            //int input3 = int.Parse(Console.ReadLine());

            //int[] final = { input, input3 };

            //int sum = SumInteger(final);
            ////Console.WriteLine(sum);
            //DateTime hireDate = new DateTime(2022, 12, 3);
            //Console.WriteLine(hireDate);

            //DateTime startDate = hireDate.AddDays(23);
            //Console.WriteLine(startDate);
            //DateTime endDate = startDate.AddDays(23);
            //Console.WriteLine(endDate);
            //int dayOfTheYear = endDate.DayOfYear;
            //Console.WriteLine(dayOfTheYear);
            //bool isDaylight = endDate.IsDaylightSavingTime();
            //DateTime hiredate = new DateTime(2022, 5, 6, 10, 07, 54);
            //Console.WriteLine(hiredate);

            //DateTime startDate = hiredate.AddDays(14);
            //bool isDaylightSaving = startDate.IsDaylightSavingTime();

            //TimeSpan worktime = new TimeSpan(7, 59, 59);


            //var startHour = DateTime.Now;

            //var endhour = startHour.Add(worktime);
            //Console.WriteLine(endhour);
            //Console.WriteLine(endhour.ToShortTimeString());


            int max = int.Parse(Console.ReadLine());
            for (int i = 0; i < max; i++)
            {

                Console.WriteLine(i);
                continue;
                break;
            }


            //Write a c# staff management program that is used to check the clocking in and clocking out of staff..
            //Then their shoufl also be a create staff method or delete staff if the staff clocks in at the wrong time for a long while,
            // resumes late 3 consecutive times
            //To clock in, the staff needs a name and a start time which is initialoizeed immediately they clock in and then the expected end time is initalized
            //and to clock out, staff name also and then the date time .now is checked and compared with the expected end time...if it is lower, the user should be promted that they didn't spend enough time working and their salary shouldn't be paid in full..
            //which then is used to compare the end time
        }
        //int vowelCount = CountVowels(input);

        //Console.WriteLine("The number of vowels in the string is: " + vowelCount);


        //public static class StringExtensions
        //{
        //    public static bool StartsWith(this string str, string prefix)
        //    {
        //        return str.StartsWith(prefix);
               
             
        //    }
        //}
        //public static class ListExtensions
        //{
        //    public static string ToDelimitedString<T>(this List<T> list, string delimiter)
        //    {
        //        return string.Join(delimiter, list);
        //    }
        //}


      


        static int CountVowels(string str)
        {
            int count = 0;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            foreach (char c in str)
            {
                if (Array.IndexOf(vowels, c) != -1)
                {
                    count++;
                }
            }

            return count;
        }


        static int SumInteger(int[] a)
        {
            int sum = 0;

            foreach (int i in a)
            {
                sum += i;
            }

            return sum;
        }
    }




}
