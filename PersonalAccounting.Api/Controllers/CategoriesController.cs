using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoriesService categoriesService)
        {
            _logger = logger;
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
            _logger.LogInformation("Enter to CategoriesController GetByBudgetId");
            
            var categories = _categoriesService.GetCategoriesByBudgetId(budgetId);

            return categories;
        }

        // POST: api/Categories
        [HttpPost]
        public async Task Post([FromBody] Category category)
        {
            _logger.LogInformation("Enter to CategoriesController Post");
            
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
