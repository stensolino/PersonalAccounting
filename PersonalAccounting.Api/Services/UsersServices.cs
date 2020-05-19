using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Database;
using PersonalAccounting.Domain.Dto;
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

        public async Task CreateUserAsync(UserDto user)
        {
            var userDb = new User
            {
                CognitoId = user.CognitoId,
                Email = user.Email,
            };

            await _appDbContext.Users.AddAsync(userDb);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
