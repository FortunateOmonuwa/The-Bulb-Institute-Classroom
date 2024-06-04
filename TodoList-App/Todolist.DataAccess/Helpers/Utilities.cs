using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist.DataAccess.DataContext;
using Todolist.Domain.Models;

namespace Todolist.DataAccess.Helpers
{
    public static class Utilities
    {
        public static TodoListContext database = new TodoListContext();
        public static async Task<User> CheckUser(int id)
        {
            //using(var database = new TodoListContext())
            {
                var user = await database.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    Console.WriteLine("User already exists");
                    throw new ArgumentNullException("User does not exist");

                }

            }
        }
    }
}
