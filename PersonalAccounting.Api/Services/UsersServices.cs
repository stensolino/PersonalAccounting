using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Database;
using PersonalAccounting.Domain.Dto;
using PersonalAccounting.Domain.Entities;
using PersonalAccounting.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Api.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IAppDbContext _appDbContext;

        public UsersServices(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<long> CreateUserAsync(UserDto user)
        {
            var userDb = new User
            {
                CognitoId = user.CognitoId,
                Email = user.Email,
            };

            await _appDbContext.Users.AddAsync(userDb);
            await _appDbContext.SaveChangesAsync();

            var budgetDb = new Budget
            {
                Name = "Primary",
                UserId = userDb.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };


            await _appDbContext.Budgets.AddAsync(budgetDb);
            await _appDbContext.SaveChangesAsync();

            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Hangout",
                    MaxAmount = 400,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    BudgetId = budgetDb.Id,
                    Type = CategoryType.Outcome
                },
                new Category
                {
                    Name = "Food",
                    MaxAmount = 200,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    BudgetId = budgetDb.Id,
                    Type = CategoryType.Outcome
                },
                new Category
                {
                    Name = "Fuel",
                    MaxAmount = 200,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    BudgetId = budgetDb.Id,
                    Type = CategoryType.Outcome
                },
                new Category
                {
                    Name = "Maintenance",
                    MaxAmount = 200,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    BudgetId = budgetDb.Id,
                    Type = CategoryType.Outcome
                }
            };
            
            await _appDbContext.Categories.AddRangeAsync(categories);
            await _appDbContext.SaveChangesAsync();

            return userDb.Id;
        }
    }
}
