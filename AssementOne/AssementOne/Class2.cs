using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssementOne
{
    public class Class2 
    {
        public Class2(string name) 
        {
            _name = name;
        }

   

        public string Name { get { return _name; } }//Properties are written in pascal case

        private string _name; // Fields are written in




        //public class ITheBulb
        //{

        //    public int CalculateSalaryAfterTaxes(int amount, int tax)
        //    {
        //        var response = GetClass(amount, tax);
        //        return response;
        //    }

        //    public int GetFinalAmount(int amount , int tax, int price)
        //    {

        //        var res = GetClass(amount, tax);
        //        return res;
        //    }
        //    int GetClass(int amount, int tax) 
        //    {
        //        return amount - tax;
        //    }
        //}
    }

   
}
