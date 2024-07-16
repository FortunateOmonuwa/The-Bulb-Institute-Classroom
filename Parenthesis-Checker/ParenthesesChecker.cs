using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parenthesis_Checker
{
    public class ParenthesesChecker
    {
        public static bool CheckPar(string input)
        {
            int balance = 0;
            foreach (char c in input)
            {
                if(c == '(')
                {
                    balance++;
                }else if(c == ')')
                {
                    balance--;

                    if(balance < 0)
                    {
                        return false;
                    }
                }
            } return true;
        }  
    }
}
