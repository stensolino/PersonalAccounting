using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Domain.Entities;

namespace PersonalAccounting.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        // GET: api/Categories
        [HttpGet]
        public string[] Get()
        {
            return new[] { "", "" };
        }

        // GET: api/Budgets/1/Categories
        [HttpGet("/api/Budgets/{budgetId}/Categories")]
        public IEnumerable<Category> GetByBudgetId(int budgetId)
        {
            var categories = _categoriesService.GetCategoriesByBudgetId(budgetId);

            return categories;
        }

        // POST: api/Categories
        [HttpPost]
        public async Task Post([FromBody] Category category)
        {
            await _categoriesService.Insert(category);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
