using Spendee.Models;
using Spendee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<Expense> Add(Expense expense)
        {
            if (_expenseRepository.Search(e => e.Name == expense.Name).Result.Any())
                return null;
            await _expenseRepository.Add(expense);

            return expense;
        }

        public void Dispose()
        {
            _expenseRepository?.Dispose();
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            return await _expenseRepository.GetAll();
        }

        public async Task<Expense> GetById(int id)
        {
            return await _expenseRepository.GetById(id);
        }

        public async Task<IEnumerable<Expense>> GetExpensesByCategory(int categoryId)
        {
            return await _expenseRepository.GetExpensesByCategory(categoryId);
        }

        public async Task<bool> Remove(Expense expense)
        {
            await _expenseRepository.Remove(expense);
            return true;
        }

        public async Task<IEnumerable<Expense>> Search(string expenseName)
        {
            return await _expenseRepository.Search(e => e.Name.Contains(expenseName));
        }

        public async Task<IEnumerable<Expense>> SearchExpenseWithCategory(string searchedValue)
        {
            return await _expenseRepository.SearchExpenseWithCategory(searchedValue);
        }

        public async Task<Expense> Update(Expense expense)
        {
            if (_expenseRepository.Search(e => e.Name == expense.Name && e.Id!=expense.Id).Result.Any())
                return null;
            await _expenseRepository.Update(expense);
            return expense;
        }
    }
}
