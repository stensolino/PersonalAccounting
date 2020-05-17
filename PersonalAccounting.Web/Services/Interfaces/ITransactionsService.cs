using PersonalAccounting.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services.Interfaces
{
    public interface ITransactionsService
    {
        Task<List<TransactionDto>> GetByBudgetId(int id);
        Task Insert(TransactionDto transaction);
    }
}
