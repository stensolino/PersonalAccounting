using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Domain.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalAccounting.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        private readonly IBudgetsService _budgetsService;
        private readonly ILogger<BudgetsController> _logger;

        public BudgetsController(ILogger<BudgetsController> logger, IBudgetsService budgetsService)
        {
            _logger = logger;
            _budgetsService = budgetsService;
        }

        // GET api/Budgets
        [HttpGet("/api/Budgets")]
        public async Task<IEnumerable<BudgetDto>> GetByUserId()
        {
            _logger.LogInformation("Enter to BudgetsController GetByUserId");

            var cognitoId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            _logger.LogInformation($"CognitoId: {cognitoId}");

            return await _budgetsService.GetByCognitoUserId(cognitoId);
        }

        // POST api/<BudgetsController>
        [HttpPost]
        public async Task Post([FromBody] BudgetDto budget)
        {
            await _budgetsService.Insert(budget);
        }

        // PUT api/<BudgetsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BudgetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
