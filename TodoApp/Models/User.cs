using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class User
    {
        //Fields
        private int _id;
        private string _name;

        //constructor

        public User(int id, string name)
        {
            _id = id;
            _name = name;
        }

        //Properties

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }


    }
}
