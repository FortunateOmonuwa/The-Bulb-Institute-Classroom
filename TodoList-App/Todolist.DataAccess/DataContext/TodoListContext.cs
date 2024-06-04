using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist.Domain.Models;

namespace Todolist.DataAccess.DataContext
{
    public class TodoListContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(" Data Source=FREE-MAN\\SQLEXPRESS02;Database= TodoListDB; Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
           
            
            //server or Data source, Database or Initial Cataloug, Integrated Security=True, Trust Server Certificate=True
        }
    }
}
