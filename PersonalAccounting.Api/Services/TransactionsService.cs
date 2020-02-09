using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Database;
using PersonalAccounting.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PersonalAccounting.Api.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly IAppDbContext _appDbContext;

        public TransactionsService(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Transaction> GetByBudgetId(int budgetId)
        {
            var result = _appDbContext.Transactions.Where(b => b.BudgetId == budgetId)
            .Include(i => i.Category);

            return result;
        }
    }
}
