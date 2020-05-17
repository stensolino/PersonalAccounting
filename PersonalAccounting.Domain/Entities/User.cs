using System.Collections.Generic;

namespace PersonalAccounting.Domain.Entities
{
    public class User : BaseEntity
    {
        public string CognitoId { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
    }
}
