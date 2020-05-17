using System.Collections.Generic;

namespace PersonalAccounting.Dto
{
    public class UserDto
    {
        public long Id { get; set; }
        public string CognitoId { get; set; }
        public string Email { get; set; }
        public List<BudgetDto> Budgets { get; set; }
    }
}
