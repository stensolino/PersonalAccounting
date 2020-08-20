using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Database;
using PersonalAccounting.Domain.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccounting.Api.Services
{
    public class BudgetsService : IBudgetsService
    {
        private readonly IAppDbContext _dbContext;

        public BudgetsService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<BudgetDto>> GetByCognitoUserId(string cognitoUserId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.CognitoId == cognitoUserId);

            var result = await _dbContext.Budgets
                .Where(b => b.UserId == user.Id)
                .Select(x => new BudgetDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return result;
        }
    }
}
