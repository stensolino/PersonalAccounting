using PersonalAccounting.Domain.Dto;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services.Interfaces
{
    public interface IBudgetService
    {
        Task<BudgetDto> GetBudget(int id);
    }
}
