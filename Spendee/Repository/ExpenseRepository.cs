using Spendee.Data;
using Spendee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.Repository
{
    public class ExpenseRepository
    {
        private readonly DataContext _context;

        public ExpenseRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Expense entity)
        {
            _context.Expenses.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Expense entity)
        {
            _context.Expenses.Remove(entity);
            _context.SaveChanges(); 
        }

        public Expense Get(long id)
        {
            return _context.Expenses.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Expense> GetAll()
        {
            return _context.Expenses.ToList();
        }

        public void Update(Expense expense, Expense entity)
        {
            expense.Name=entity.Name;
            _context.SaveChanges();    
        }
    }
}
