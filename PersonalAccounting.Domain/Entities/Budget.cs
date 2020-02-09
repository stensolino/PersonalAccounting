using System.Collections.Generic;

namespace PersonalAccounting.Domain.Entities
{
    public class Budget : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
