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
            int a = 0;
        for (int i = 1; i < arrayOfIntegers.Length; i++)
            {
                if (arrayOfIntegers[i] % i == 0){a++;}
            }
        if(a == 0) { }
        }

       
    }
}
