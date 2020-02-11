using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Database;
using PersonalAccounting.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IEnumerable<Category> GetCategories(int budgetId)
        {
            var result = _appDbContext.Categories.Where(c => c.Transactions.Any(t => t.BudgetId == budgetId));

            return result;
        }

        public async Task Insert(Transaction transaction)
        {
            await _appDbContext.Transactions.AddAsync(transaction);
            await _appDbContext.SaveChangesAsync();

            var ne = _appDbContext.Categories.Where(c => c.Transactions.Any(a => a.BudgetId == 1));
        }
    }
}
