using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services
{
    public interface IBudgetService
    {
        Task GetBudget(int id);
    }
}
