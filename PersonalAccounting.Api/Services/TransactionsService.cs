using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Database;
using PersonalAccounting.Domain.Entities;
using PersonalAccounting.Dto;
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
                    Date = s.Date
                });

            return transactions;
        }

        public async Task Insert(Transaction transaction)
        {
            try
            {
                //TODO
                transaction.BudgetId = 1;

                var categoty = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == transaction.CategoryId);
                //transaction.Category = categoty;

                await _dbContext.Transactions.AddAsync(transaction);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
