using PersonalAccounting.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<Category>> GetCategories(int budgetId);
    }
}
