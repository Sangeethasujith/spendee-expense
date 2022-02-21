using Spendee.Data;
using Spendee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.Repository
{
    public class CategoryRepository { 
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Category entity)
        {
            _context.Categories.Remove(entity);
            _context.SaveChanges();
        }

        public Category Get(long id)
        {
            return _context.Categories.FirstOrDefault(c=>c.Id==id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Update(Category category, Category entity)
        {
           category.Name=entity.Name;
            _context.SaveChanges();           
        }
    }
}
