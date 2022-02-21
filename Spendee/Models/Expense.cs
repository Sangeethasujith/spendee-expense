using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.Models
{
    public class Expense: Entity
    {
        public string Name;
        public double Value;
        public int CategoryId;
        public DateTime Date;
        public string PaymentType;

        public Category Category
;

    }
}
