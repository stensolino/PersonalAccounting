using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services.Interfaces
{
    public interface IBudgetService
    {
        Task GetBudget(int id);
    }
}
