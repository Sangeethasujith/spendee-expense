using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.DTOs
{
    public class CategoryAddDto
    {
        [Required(ErrorMessage="This field{0} is required")]

        public string Name { get; set; }

    }
}
