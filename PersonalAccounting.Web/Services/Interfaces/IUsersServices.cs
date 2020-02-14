using PersonalAccounting.Domain.Entities;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services.Interfaces
{
    public interface IUsersServices
    {
        Task CreateUserAsync(User user);
    }
}
