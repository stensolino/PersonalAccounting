using PersonalAccounting.Domain.Entities;
using System.Collections.Generic;

namespace PersonalAccounting.Api.Services.Interfaces
{
    public interface ITransactionsService
    {
        IEnumerable<Transaction> GetByBudgetId(int budgetId);
    }
}
