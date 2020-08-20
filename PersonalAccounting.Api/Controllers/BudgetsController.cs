using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Domain.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalAccounting.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        private readonly IBudgetsService _budgetsService;

        public BudgetsController(IBudgetsService budgetsService)
        {
            _budgetsService = budgetsService;
        }

        // GET api/Budgets
        [HttpGet("/api/Budgets")]
        public async Task<IEnumerable<BudgetDto>> GetByUserId()
        {
            var cognitoId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return await _budgetsService.GetByCognitoUserId(cognitoId);
        }

        // POST api/<BudgetsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
