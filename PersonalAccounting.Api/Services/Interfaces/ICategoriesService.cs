using PersonalAccounting.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Api.Services.Interfaces
{
    public interface ICategoriesService
    {
        IEnumerable<Category> GetCategoriesByBudgetId(int budgetId);
        Task Insert(Category category);
    }
}
