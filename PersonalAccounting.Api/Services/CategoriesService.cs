using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Database;
using PersonalAccounting.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccounting.Api.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IAppDbContext _appDbContext;

        public CategoriesService(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> GetCategoriesByBudgetId(int budgetId)
        {
            var result = _appDbContext.Categories
                .Where(c => c.BudgetId == budgetId)
                .Select(s => new Category
                {
                    Id = s.Id,
                    Name = s.Name
                });

            return result;
        }

        public async Task Insert(Category category)
        {
            _appDbContext.Categories.Add(category);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
