using Spendee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.Services
{
    public interface IExpenseService:IDisposable
    {
        Task<IEnumerable<Expense>> GetAll();
        Task<Expense> GetById(int id);
        Task<Expense> Add(Expense expense);
        Task<Expense> Update(Expense expense);
        Task<bool> Remove(Expense expense);
        Task<IEnumerable<Expense>> GetExpensesByCategory(int categoryId);
        Task<IEnumerable<Expense>> Search(string expenseName);
        Task<IEnumerable<Expense>> SearchExpenseWithCategory(string searchedValue);
    }
}
