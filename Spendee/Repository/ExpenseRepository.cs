using Microsoft.EntityFrameworkCore;
using Spendee.Data;
using Spendee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.Repository
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(DataContext context) : base(context) { }

        public override async Task<List<Expense>> GetAll()
        {
            return await Db.Expenses.AsNoTracking().Include(e => e.Category).OrderBy(e => e.Name).ToListAsync();
        }

        public override async Task<Expense> GetById(int id)
        {
            return await Db.Expenses.AsNoTracking().Include(e => e.Category).Where(e => e.Id==id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesByCategory(int categoryId)
        {
            return await Search(c => c.CategoryId == categoryId);
        }

        public async Task<IEnumerable<Expense>> SearchExpenseWithCategory(string searchedValue)
        {
            return await Db.Expenses.AsNoTracking()
                .Include(e => e.Category)
                .Where(e => e.Name.Contains(searchedValue) ||
                        e.PaymentType.Contains(searchedValue) ||
                        e.Category.Name.Contains(searchedValue)).ToListAsync();
        }
    }
}
