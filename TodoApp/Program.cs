using System;

namespace TodoApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var TodoApp = new TodoList();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Pls enter a valid option\n1 : Add Task.\n2 : Remove Task.\n3 : Mark Task as Completed.\n4 : Display Task.\n5 : Exit program.\n---------------------------------------");
                int userInput = int.Parse(Console.ReadLine());
                if(userInput == 1)
                {
                    TodoApp.AddTask();
                }
                else if(userInput == 2)
                {
                    TodoApp.RemoveTask();
                }
            }

            
        }
    }
}
