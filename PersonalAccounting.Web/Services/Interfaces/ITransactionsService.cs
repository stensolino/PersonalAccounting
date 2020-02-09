using PersonalAccounting.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services.Interfaces
{
    public interface ITransactionsService
    {
        Task<List<Transaction>> GetByBudgetId(int id);
    }
}
