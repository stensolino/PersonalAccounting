using System.Collections.Generic;

namespace PersonalAccounting.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string CognitoId { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Budget> Budgets { get; set; }
    }
}
