using PersonalAccounting.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services.Interfaces
{
    public interface IBudgetsService
    {
        Task<List<BudgetDto>> GetBudgetsByUserId();
        Task<BudgetDto> GetBudget(int id);
        Task InsertBudget(BudgetDto budget);
    }
}
