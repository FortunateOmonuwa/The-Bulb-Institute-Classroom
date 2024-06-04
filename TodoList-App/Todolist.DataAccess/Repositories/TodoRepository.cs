using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist.DataAccess.DataContext;
using Todolist.DataAccess.Helpers;
using Todolist.DataAccess.Interfaces;
using Todolist.Domain.DTOs;
using Todolist.Domain.Models;

namespace Todolist.DataAccess.Repositories
{
    public class TodoRepository : ITodoRepository
    {
       
        public  async Task<TodoItem> AddTodoItem(TodoItemCreateDTO newItem, int user_id)
        {
            try
            {
                var user = await Utilities.CheckUser(user_id);
                var new_item = new TodoItem
                {
                    UserId = user_id,
                    DateCreated = DateTime.Now,
                    DueDate = newItem.DueDate,
                    Name = newItem.Name,
                    Description = newItem.Description,
                    Completed = false
                };
                await Utilities.database.TodoItems.AddAsync(new_item);
               // user.Tasks.Add(new_item);
                await Utilities.database.SaveChangesAsync();
                return new_item;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n\n {ex.Source}");
                throw new Exception($"{ex.Message}\n\n {ex.Source}");
            }
        }

        public Task<string> DeleteItem(int item_id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoItem>> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> GetItemById(int item_id)
        {
            throw new NotImplementedException();
        }


        //Check with id first to confrim
        public Task<string> UpdateCompletedStatus(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> UpdateItem(TodoItemCreateDTO item, int item_id)
        {
            throw new NotImplementedException();
        }
    }
}
