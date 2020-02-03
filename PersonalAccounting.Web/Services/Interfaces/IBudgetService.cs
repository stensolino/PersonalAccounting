using PersonalAccounting.Domain.Entities;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services.Interfaces
{
    public interface IBudgetService
    {
        Task<Budget> GetBudget(int id);
    }
}
