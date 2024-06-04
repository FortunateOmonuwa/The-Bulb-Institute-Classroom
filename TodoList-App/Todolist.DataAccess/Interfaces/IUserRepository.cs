using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist.Domain.DTOs;
using Todolist.Domain.Models;

namespace Todolist.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddUser(CreateUserDTO newUser);
        Task<User> GetUserById(int user_id);
        Task <List<User>> GetAllUsers();
        Task <string> DeleteUser(int user_id);
        Task<User> UpdateUser(CreateUserDTO user, int user_id);
    }
}
