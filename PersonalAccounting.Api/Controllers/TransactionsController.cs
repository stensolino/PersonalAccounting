using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Domain.Dto;
using PersonalAccounting.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;
        private readonly ITransactionsService _transactionService;

        public TransactionsController(ILogger<TransactionsController> logger, ITransactionsService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        // GET: api/Transactions
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Budgets/1/Transactions
        [HttpGet("/api/Budgets/{id}/Transactions")]
        public ActionResult<IEnumerable<TransactionDto>> GetByBudgetId(int id)
        {
            _logger.LogInformation("Enter to TransactionsController GetByBudgetId");

            var transactions = _transactionService.GetByBudgetId(id);

            return Ok(transactions);
        }

        // POST: api/Transactions
        [HttpPost]
        public async Task Post([FromBody] Transaction transaction)
        {
            _logger.LogInformation("Enter to TransactionsController Post");

            await _transactionService.Insert(transaction);
        }

        // PUT: api/Transactions/5
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
