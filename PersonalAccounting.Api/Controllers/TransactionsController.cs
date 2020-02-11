using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Domain.Entities;

namespace PersonalAccounting.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionService;
        public TransactionsController(ITransactionsService transactionService)
        {
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
        public ActionResult<IEnumerable<Transaction>> GetByBudgetId(int id)
        {
            var transactions = _transactionService.GetByBudgetId(id);

            return Ok(transactions);
        }

        // POST: api/Transactions
        [HttpPost]
        public async Task Post([FromBody] Transaction transaction)
        {            
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
