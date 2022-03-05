using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spendee.DTOs;
using Spendee.Models;
using Spendee.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.Controllers
{
    [Route("api/[controller]")]
    public class ExpenseController : HomeController
    {
        private readonly IExpenseService _expenseService;
        private readonly IMapper _mapper;

        public ExpenseController(IExpenseService expenseService,IMapper mapper)
        {
            _expenseService = expenseService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var expenses = await _expenseService.GetAll();
            return Ok(_mapper.Map<IEnumerable<ExpenseResultDto>>(expenses));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            var expense = await _expenseService.GetById(id);
            if (expense == null) return NotFound();

            return Ok(_mapper.Map<ExpenseResultDto>(expense));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, ExpenseEditDto expenseEditDto)
        {
            if (id != expenseEditDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _expenseService.Update(_mapper.Map<Expense>(expenseEditDto));

            return Ok(expenseEditDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(ExpenseAddDto expenseAddDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var expense = _mapper.Map<Expense>(expenseAddDto);
            var expenseResult = await _expenseService.Add(expense);

            if (expenseResult == null) return BadRequest();

            return Ok(_mapper.Map<ExpenseResultDto>(expenseResult));
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove(int id)
        {
            var expense =await _expenseService.GetById(id);

            if (expense == null) return NotFound();

            var result = await _expenseService.Remove(expense);

            if (!result) return BadRequest();
            return Ok();

        }
        [HttpGet]
        [Route("get-expenses-by-category/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExpensesByCategory(int categoryId)
        {
            var expenses = await _expenseService.GetExpensesByCategory(categoryId);

            if (!expenses.Any()) return NotFound();

            return Ok(_mapper.Map<IEnumerable<ExpenseResultDto>>(expenses));
        }

        [HttpGet]
        [Route("search-expense-with-category/{searchedValue}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SearchExpensesWithCategory(string searchedValue)
        {
            var expenses = _mapper.Map<List<Expense>>(await _expenseService.SearchExpenseWithCategory(searchedValue));

            if (!expenses.Any()) return NotFound();

            return Ok(_mapper.Map<IEnumerable<ExpenseResultDto>>(expenses));
        }
    }
}
