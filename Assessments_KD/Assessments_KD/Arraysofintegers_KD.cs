using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments_KD
{
    public class Arraysofintegers_KD
    {

        public static void Main() { 
        int[] arrayOfIntegers = { 3, 4, 5, 9, 3, 24, 2, 1, 32, 12 };

            int isPrime;
            int isEven;
            int isOdd;
            int sumPrime;
            int sumEven;
            int sumOdd;


        foreach (int num in arrayOfIntegers) 
            {
                if (arrayOfIntegers[num] % num == 0) 
                {
                    isPrime =2;
                    for (int i = 2; i <= Math.Sqrt(i); i++)
                    {

                        isPrime++;

                        Console.WriteLine(num);
                    }
                }


                /**else if (arrayOfIntegers[num] % 2 == 0) 
                {
                    isEven
                }**/
            }
            
            
            
            /**int a = 0;
        for (int i = 1; i < arrayOfIntegers.Length; i++)
            {
                if (arrayOfIntegers[i] % i == 0){a++;}
            }
        if(a == 0) { }**/
        }


    }
}
