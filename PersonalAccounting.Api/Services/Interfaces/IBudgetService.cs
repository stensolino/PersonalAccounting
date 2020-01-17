using PersonalAccounting.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Api.Services.Interfaces
{
    public interface IBudgetService
    {
        Task<IEnumerable<Budget>> GetAll();
        Task<Budget> GetById(int id);
        Task<Budget> Update(Budget budget);
        Task<Budget> Insert(Budget budget);
        Task<Budget> Delete(int id);
    }
}
