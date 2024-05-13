using OOP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{

    //------------- Animal is the derived class, Cat is the base class
    internal class Cat : IAnimal// Animal becomes the derived class...Animal class is the parent class, Cat class becomes the child classs
    {
        public string Sound { get; set; }
        public string NumberOfLegs { get; set; }

        public string GetAnimalName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
