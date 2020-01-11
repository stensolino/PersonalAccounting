using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Domain.Entities;

namespace PersonalAccounting.Database
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Budget> Budgets { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Transaction> Transactions { get; set; }
    }
}
