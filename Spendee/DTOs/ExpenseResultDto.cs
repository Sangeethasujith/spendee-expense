using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.DTOs
{
    public class ExpenseResultDto
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
       
        public double Value { get; set; }
        
        public int CategoryId { get; set; }
        
        public DateTime Date { get; set; }
        
        public string PaymentType { get; set; }

        public string CategoryName { get; set; }
    }
}
