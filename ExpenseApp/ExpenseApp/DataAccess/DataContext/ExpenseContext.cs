using ExpenseApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApp.DataAccess.DataContext
{
    public class ExpenseContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=FREE-MAN\\SQLEXPRESS02; Database=Spenny-WiseDB; Integrated Security=True;Trust Server Certificate=True;");
        }
    }
}
