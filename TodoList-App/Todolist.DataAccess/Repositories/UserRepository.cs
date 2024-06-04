using Microsoft.EntityFrameworkCore;
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
    public class UserRepository : IUserRepository
    {
        public TodoListContext database = new TodoListContext();
        public async Task<User> AddUser(CreateUserDTO newUser)
        {
            //using var database = new TodoListContext();
            try
            {
                var user = await database.Users.FirstOrDefaultAsync(x => x.Name == newUser.Name);
                if (user != null)
                {
                    throw new Exception("Username already exists");
                }
                var createUser = new User
                {
                    Name = newUser.Name,

                };
                await database.Users.AddAsync(createUser);
                await database.SaveChangesAsync();

                return createUser;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n\n {ex.Source}");
                throw new Exception($"{ex.Message}\n\n {ex.Source}");
            }
        }

        public async Task<string> DeleteUser(int user_id)
        {
            try
            {
                var user = Utilities.CheckUser(user_id);
                if(user == null)
                {
                    Console.WriteLine("User does not exist");
                    throw new ArgumentNullException("User does not exist");
                }
                else
                {
                     database.Users.Remove(user.Result);
                    await database.SaveChangesAsync();
                    return "User deleted successfully";
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n\n {ex.Source}");
                throw new Exception($"{ex.Message}\n\n {ex.Source}");
            }
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(int user_id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateUser(CreateUserDTO userToUpdate, int user_id)
        {
            try
            {
                var user =  await Utilities.CheckUser(user_id);
                user.Id = user.Id;
                user.Name = userToUpdate.Name ?? user.Name;
                user.Tasks = userToUpdate.Tasks ?? user.Tasks;

                database.Users.Update(user);
                await database.SaveChangesAsync();
                return user;


            }
            catch( Exception ex )
            {
                Console.WriteLine($"{ex.Message}\n\n {ex.Source}");
                throw new Exception($"{ex.Message}\n\n {ex.Source}");
            }
        }

       
    }
}
