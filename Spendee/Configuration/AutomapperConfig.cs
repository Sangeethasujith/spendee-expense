using AutoMapper;
using Spendee.DTOs;
using Spendee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryEditDto>().ReverseMap();
            CreateMap<Category, CategoryResultDto>().ReverseMap();

            CreateMap<Expense, ExpenseAddDto>().ReverseMap();
            CreateMap<Expense, ExpenseEditDto>().ReverseMap();
            CreateMap<Expense, ExpenseResultDto>().ReverseMap();
        }        
    }
}
