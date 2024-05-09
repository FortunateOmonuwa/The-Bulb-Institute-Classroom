using System;
using TodoApp.Actions;
using TodoApp.Models;

namespace TodoApp
{
    public class Program
    {
        static void Main(string[] args)
        {
           while (true)
            {
                Console.WriteLine("Welcome");
                var userChoice = Menu.StartApp();



                Menu.ActivateSelection(userChoice);
                //Console.Clear();
            }
          
                   
                
           

            
        }
    }
}
