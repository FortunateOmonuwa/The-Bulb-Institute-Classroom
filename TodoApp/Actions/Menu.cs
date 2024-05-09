using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Models;
using TodoApp.Actions;

namespace TodoApp.Actions
{
    public class Menu
    {
       
        public static int StartApp()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Welcome to Akanbi todo app");

            Console.WriteLine("Pls enter a valid option\n1 : Add Task.\n2 : Remove Task.\n3 : Mark Task as Completed.\n4 : Display Task.\n5 : Exit program.\n---------------------------------------");

            var userChoice = int.Parse(Console.ReadLine());
            return userChoice;

        }

        
        public static void ActivateSelection(int userChoce)
        {
            TodoList TodoAction = new TodoList();

            switch(userChoce)
            {
                case 1:
                    Console.WriteLine("Add task");
                    TodoAction.AddTask();
                    break;

                case 2:
                    Console.WriteLine("Remove Task");
                    TodoAction.RemoveTask();
                    break;
                case 3:
                    Console.WriteLine("Marked task as completed");
                    TodoAction.MarkTaskAsCompleted();
                    break;
                case 4:
                    Console.WriteLine("You have choosen to display task");
                    TodoAction.DisplayTasks();
                    break;
                case 5:
                    TodoAction.ExitTasks();
                    break;
                default:
                    Console.WriteLine("Invalid input, pls try again");
                    break;


            }
        }
    }
}
