using System.Collections.Generic;

namespace PersonalAccounting.Domain.Entities
{
    public class User
    {
        public virtual ICollection<Budget> Budgets { get; set; }
    }
}
