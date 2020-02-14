using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Database;
using PersonalAccounting.Domain.Entities;
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

        public async Task CreateUserAsync(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
