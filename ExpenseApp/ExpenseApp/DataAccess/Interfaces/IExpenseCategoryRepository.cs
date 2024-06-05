using ExpenseApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApp.DataAccess.Interfaces
{
    public interface IExpenseCategoryRepository
    {
        Task<List<ExpenseCategory>> GetAllCategories();
    }
}
