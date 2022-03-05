using Spendee.Models;
using Spendee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IExpenseService _expenseService;

        public CategoryService(ICategoryRepository categoryRepository,IExpenseService expenseService)
        {
            _categoryRepository = categoryRepository;
            _expenseService = expenseService;
        }
        public async Task<Category> Add(Category category)
        {
            if (_categoryRepository.Search(c => c.Name == category.Name).Result.Any())
                return null;

            await _categoryRepository.Add(category);
            return category;
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<bool> Remove(Category category)
        {
            var expenses = await _expenseService.GetExpensesByCategory(category.Id);
            if (expenses.Any())
                return false;
            await _categoryRepository.Remove(category);
            return true; 
        }

        public async Task<IEnumerable<Category>> Search(string categoryName)
        {
            return await _categoryRepository.Search(c => c.Name.Contains(categoryName));
        }

        public async Task<Category> Update(Category category)
        {
            if (_categoryRepository.Search(c => c.Name == category.Name && c.Id != category.Id).Result.Any())
                return null;

            await _categoryRepository.Update(category);
            return category;
        }
    }
}
