using PersonalAccounting.Domain.Entities;
using PersonalAccounting.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Api.Services.Interfaces
{
    public interface ITransactionsService
    {
        IEnumerable<TransactionDto> GetByBudgetId(int budgetId);
        Task Insert(Transaction transaction);
    }
}
