using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Database;
using PersonalAccounting.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Api.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IAppDbContext _appDbContext;

        public BudgetService(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Budget>> GetAll()
        {
            var result = await _appDbContext.Budgets.ToListAsync(); ;

            return result;
        }

        public async Task<Budget> GetById(int id)
        {
            var result = await _appDbContext.Budgets.FirstOrDefaultAsync(b => b.Id == id);

            return result;
        }

        public async Task<Budget> Update(Budget budget)
        {
            _appDbContext.Budgets.Update(budget);

            await _appDbContext.SaveChangesAsync();

            return budget;
        }

        public async Task<Budget> Insert(Budget budget)
        {
            _appDbContext.Budgets.Add(budget);

            await _appDbContext.SaveChangesAsync();

            return budget;
        }

        public async Task<Budget> Delete(int id)
        {
            var budget = await _appDbContext.Budgets.FindAsync(id);
            _appDbContext.Budgets.Remove(budget);
            
            await _appDbContext.SaveChangesAsync();

            return budget;
        }
    }
}
