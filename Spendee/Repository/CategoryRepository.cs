using Spendee.Data;
using Spendee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.Repository
{
    public class CategoryRepository :Repository<Category>,ICategoryRepository
    { 
        public CategoryRepository(DataContext context) : base(context) { }       
    }
}
