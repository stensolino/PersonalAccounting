using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalAccounting.Database
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Budget> Budgets { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Transaction> Transactions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
