using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Domain.Entities;

namespace PersonalAccounting.Database
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    //UserName = "stensolino@gmail.com",
                    Email = "stensolino@gmail.com",
                    //PasswordHash = "AQAAAAEAACcQAAAAEEUDja8AlmtidZ7eVUFFc7bgxcHMZNtJVpYQvfIuKm2UKM0KapjzLp4rsSkzIx2HxQ==",
                    //SecurityStamp = "7LEMKD4XPEBZPJIG2WCC4MWAI74HENS6",
                    //ConcurrencyStamp = "b2e31d4e-cf8b-4a43-a67d-cd0b0d1b2df4",
                    //LockoutEnabled = true
                }
            );

            modelBuilder.Entity<Budget>().HasData(
                new Budget
                {
                    Id = 1,
                    UserId = 1
                },
                new Budget
                {
                    Id = 2,
                    UserId = 1
                },
                new Budget
                {
                    Id = 3,
                    UserId = 1
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Cash",
                    MaxAmount = 50,
                    Description = "Currently cash in use",
                    BudgetId = 1
                },
                new Category
                {
                    Id = 2,
                    Name = "UniCredit Bank",
                    MaxAmount = 230,
                    Description = "My primary bank",
                    BudgetId = 1
                },
                new Category
                {
                    Id = 3,
                    Name = "UniCredit Bank",
                    MaxAmount = 29,
                    Description = "My primary bank of another user"
                }
            );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    Id = 1,
                    CategoryId = 1,
                    Amount = 15,
                    Note = "Drink",
                    BudgetId = 1
                },
                new Transaction
                {
                    Id = 2,
                    CategoryId = 1,
                    Amount = 47,
                    Note = "Lunch",
                    BudgetId = 1
                },
                new Transaction
                {
                    Id = 3,
                    CategoryId = 2,
                    Amount = 9000,
                    Note = "Salary",
                    BudgetId = 1
                },
                new Transaction
                {
                    Id = 4,
                    CategoryId = 2,
                    Amount = 55,
                    Note = "Bill",
                    BudgetId = 1
                }
            );
        }
    }
}
