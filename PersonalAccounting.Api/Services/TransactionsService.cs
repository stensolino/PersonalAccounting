using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Database;
using PersonalAccounting.Domain.Dto;
using PersonalAccounting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccounting.Api.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly IAppDbContext _dbContext;

        public TransactionsService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TransactionDto> GetByBudgetId(int budgetId)
        {
            var transactions = _dbContext.Transactions
                .Where(t => t.BudgetId == budgetId)
                .Select(s => new TransactionDto
                {
                    Id = s.Id,
                    Amount = s.Amount,
                    Note = s.Note,
                    Date = s.Date,
                    CategoryId = s.CategoryId,
                    CategoryName = s.Category.Name
                });

            return transactions;
        }

        public async Task Insert(Transaction transaction)
        {
            await _dbContext.Transactions.AddAsync(transaction);
            await _dbContext.SaveChangesAsync();
        }
    }
}
