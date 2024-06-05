using ExpenseApp.DataAccess.DataContext;
using ExpenseApp.DataAccess.Interfaces;
using ExpenseApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApp.DataAccess.Repositories
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        public ExpenseContext database = new ExpenseContext();

        public async Task<List<ExpenseCategory>> GetAllCategories()
        {
            try
            {
                var categories = await database.ExpenseCategories.ToListAsync();
                if (categories == null)
                {
                    Console.WriteLine("There were no categories on the db");
                    throw new ArgumentNullException("There were no categories on the db");
                }
                else
                {
                    return categories;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
