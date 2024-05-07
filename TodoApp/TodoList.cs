using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoList
    {
        private int _taskNumber = 0;
        private Task _task = null ;


        public int TaskNumber { get; set; }
        public Task Task { get; set; }

        public TodoList ()
        {
            _taskNumber = TaskNumber;
            _task = Task;
        }

      

        public void AddTask()
        {
            Console.WriteLine("Pls enter your task name");
            var taskName = Console.ReadLine();

            Console.WriteLine("Pls enter your task description");
            var taskDescription = Console.ReadLine();

            Console.WriteLine("Pls enter your task duedate");
            var taskDueDate =DateTime.Parse( Console.ReadLine());

            Task newTask = new Task(taskName,taskDescription,taskDueDate);

            TaskNumber++;
            Console.WriteLine("----------------New Task Created----------------");
            Console.WriteLine($"{TaskNumber} TASK CREATED !!!\nTask Name : {newTask.Name}.\nTask description : {newTask.Description}.\nDuedate : {newTask.DueDate}");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("------------------------------------------------");


        }

        public void RemoveTask()
        {
            Console.WriteLine("Pls enter task number");
            int userTaskNumberTobeRemoved = int.Parse( Console.ReadLine()); 

            if(userTaskNumberTobeRemoved == TaskNumber)
            {
                _task = null;
                Console.WriteLine("----------------REMOVE TASK ACTION----------------");
                Console.WriteLine($"Task number : {TaskNumber} removed !!!");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("------------------------------------------------");
            }
            else
            {
                Console.WriteLine("User task  number does not exist");
            }
        }

        public void MarkTaskAsCompleted()
        {
            Console.WriteLine("Pls enter task number to be marked as completed");
            int userTaskNumberToBeMarkedAsCompleted = int.Parse(Console.ReadLine());

            if (userTaskNumberToBeMarkedAsCompleted ==  TaskNumber && _task != null)
            {
                //Task.Completed = true;
                _task.Completed = true;
                Console.WriteLine("----------------TASK COM ----------------");

            }
            else
            {
                Console.WriteLine("TaskNumber does not exist as completed ");
            }

        }

        public void DisplayTasks()
        {
            if(_task != null)
            {
                Console.WriteLine($"Task Name : {Task.Name}.\n Descrption : {Task.Description}\n DueDate : {Task.DueDate}\n Completion Status : {Task._completed}");
            }
        }
    }
}
