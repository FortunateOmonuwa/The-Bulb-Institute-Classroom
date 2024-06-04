using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist.Domain.DTOs;
using Todolist.Domain.Models;

namespace Todolist.DataAccess.Interfaces
{
    public interface ITodoRepository
    {
        Task<TodoItem> AddTodoItem(TodoItemCreateDTO newItem, int user_id);
        Task<TodoItem> GetItemById(int item_id);
        Task<List<TodoItem>> GetAllItems();
        Task<string> DeleteItem(int item_id);
        Task<TodoItem> UpdateItem(TodoItemCreateDTO item, int item_id);
        //Check with id first to confirm item exists
        Task<string> UpdateCompletedStatus(TodoItem todoItem);
     
    }
}
