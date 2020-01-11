using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PersonalAccounting.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public virtual ICollection<Budget> Budgets { get; set; }
    }
}
