using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.Models
{
    public class Expense: Entity
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public string PaymentType { get; set; }

        public Category Category { get; set; }

    }
}
