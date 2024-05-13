using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    internal class Animal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Family { get; set; }



        //public string CreateAnimal(string name, string description, int number)
        //{
        //    var validation = ValidateInput(name, description, number);
        //    if (validation == false)
        //    {
        //        return "You entered something wrong";

        //    }
        //    Name = name;
        //    Description = description;


        //    return $"{Name}\n{Description} \n {number}";
        //}


        //private bool ValidateInput(string name, string description, int num)
        //{
        //    if (name.Length < 5 || description.Length < 5 || num < 18)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
