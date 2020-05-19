using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Domain.Entities;
using PersonalAccounting.Domain.Enum;
using System;

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
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Drink",
                    MaxAmount = 50,
                    Description = "Daily drink",
                    Type = CategoryType.Outcome,
                    BudgetId = 1
                },
                new Category
                {
                    Id = 2,
                    Name = "Food",
                    MaxAmount = 230,
                    Description = "Breakfast, Lunch, Diner...",
                    Type = CategoryType.Outcome,
                    BudgetId = 1
                },
                new Category
                {
                    Id = 3,
                    Name = "Parking",
                    MaxAmount = 230,
                    Description = "Garage, public parking...",
                    Type = CategoryType.Outcome,
                    BudgetId = 1
                },
                new Category
                {
                    Id = 4,
                    Name = "Fuel",
                    MaxAmount = 230,
                    Description = "Fuel for car",
                    Type = CategoryType.Outcome,
                    BudgetId = 1
                },
                new Category
                {
                    Id = 5,
                    Name = "Cache",
                    Description = "Current cache status",
                    Type = CategoryType.Income,
                    BudgetId = 1
                },
                new Category
                {
                    Id = 6,
                    Name = "UniCredit Bank",
                    Description = "Bank account",
                    Type = CategoryType.Income,
                    BudgetId = 1
                },
                new Category
                {
                    Id = 7,
                    Name = "Maintenance",
                    MaxAmount = 29,
                    Description = "Regular real estate maintenance",
                    Type = CategoryType.Outcome,
                    BudgetId = 2
                },
                new Category
                {
                    Id = 8,
                    Name = "Fuel",
                    MaxAmount = 29,
                    Description = "Fuel for all vehicles",
                    Type = CategoryType.Outcome,
                    BudgetId = 2
                }
            );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    Id = 1,
                    Amount = 15,
                    Note = "Some note",
                    Date = new DateTime(2020, 5, 15, 14, 30, 0, 0, DateTimeKind.Utc),
                    CategoryId = 1,
                    BudgetId = 1
                },
                new Transaction
                {
                    Id = 2,
                    Amount = 47,
                    Note = "Some note",
                    Date = new DateTime(2020, 5, 15, 14, 30, 0, 0, DateTimeKind.Utc),
                    CategoryId = 2,
                    BudgetId = 1
                },
                new Transaction
                {
                    Id = 3,
                    Amount = 33,
                    Note = "Some note",
                    Date = new DateTime(2020, 5, 15, 14, 30, 0, 0, DateTimeKind.Utc),
                    CategoryId = 3,
                    BudgetId = 1
                },
                new Transaction
                {
                    Id = 4,
                    Amount = 27,
                    Note = "Some note",
                    Date = new DateTime(2020, 5, 15, 14, 30, 0, 0, DateTimeKind.Utc),
                    CategoryId = 4,
                    BudgetId = 1
                }
            );
        }
    }
}
