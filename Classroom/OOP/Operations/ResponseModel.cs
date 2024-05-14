using OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Operations
{
    internal class ResponseModel<T>
    {
        public T Value { get { return _value; } }
        public T _value;

       


        public T GetValue(T value)
        {
            return value;
        }
    }
}
