using PersonalAccounting.Domain.Entities;
using System.Threading.Tasks;

namespace PersonalAccounting.Api.Services.Interfaces
{
    public interface IUsersServices
    {
        Task CreateUserAsync(User user);
    }
}
