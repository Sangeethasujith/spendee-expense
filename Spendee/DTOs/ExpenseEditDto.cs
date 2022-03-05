using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.DTOs
{
    public class ExpenseEditDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field{0} is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field{0} is required")]
        public double Value { get; set; }
        [Required(ErrorMessage = "This field{0} is required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "This field{0} is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "This field{0} is required")]
        public string PaymentType { get; set; }
    }
}
