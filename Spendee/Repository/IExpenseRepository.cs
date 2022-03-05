using Spendee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Spendee.Repository
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        new Task<List<Expense>> GetAll();
        new Task<Expense> GetById(int id);
        Task<IEnumerable<Expense>> GetExpensesByCategory(int categoryId);
        Task<IEnumerable<Expense>> SearchExpenseWithCategory(string searchedValue);
    }
}
