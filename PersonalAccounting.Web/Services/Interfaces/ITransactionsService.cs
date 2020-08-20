using PersonalAccounting.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services.Interfaces
{
    public interface ITransactionsService
    {
        Task<List<TransactionDto>> GetTransactionsByBudgetId(int id);
        Task InsertTransaction(TransactionDto transaction);
    }
}
