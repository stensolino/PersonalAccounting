using PersonalAccounting.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Api.Services.Interfaces
{
    public interface IBudgetsService
    {
        Task<IEnumerable<BudgetDto>> GetByCognitoUserId(string cognitoUserId);
    }
}
