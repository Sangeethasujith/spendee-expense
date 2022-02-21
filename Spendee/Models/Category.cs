using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.Models
{
    public class Category:Entity
    {
        public string Name;
        public IEnumerable<Expense> Expense;
    }
}
