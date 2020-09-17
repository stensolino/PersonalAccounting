using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Database;
using PersonalAccounting.Domain.Dto;
using PersonalAccounting.Domain.Entities;
using System;
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

        public async Task Insert(BudgetDto budgetDto)
        {
            var budget = new Budget
            {
                Name = budgetDto.Name,
                UserId = budgetDto.UserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _dbContext.Budgets.AddAsync(budget);
            await _dbContext.SaveChangesAsync();
        }
    }
}
