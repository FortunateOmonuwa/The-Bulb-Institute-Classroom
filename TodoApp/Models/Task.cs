using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Actions;

namespace TodoApp.Models
{
    public class Task
    {
        //Fields
        private string _name;
        private string _description;
        private DateTime _dueDate;
        public bool _completed = false;


        //Properties
        public string Name { get { return _name; } }
        public string Description { get { return _description; } }

        public DateTime DueDate { get { return _dueDate; } }
        public bool Completed { get; set; }


        //Contructor
        public Task(string name, string description, DateTime dueDate)
        {
            _name = name;
            _description = description;
            _dueDate = dueDate;


        }




    }
}
