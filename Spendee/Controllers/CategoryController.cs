using Microsoft.AspNetCore.Mvc;
using Spendee.Models;
using Spendee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ////private readonly IDataRepository<Category> _categoryRepositry;

        ////public CategoryController(IDataRepository<Category> categoryRepositry)
        ////{
        ////    _categoryRepositry = categoryRepositry;
        ////}

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    IEnumerable<Category> categories = _categoryRepositry.GetAll();
        //    return Ok(categories);
        //}

        //[HttpGet("{id}")]
        //public IActionResult Get(long Id)
        //{
        //    Category category = _categoryRepositry.Get(Id);
        //    if (category == null)
        //        return NotFound("category does not exist");
        //    return Ok(category);
        //}

       
    }
}
