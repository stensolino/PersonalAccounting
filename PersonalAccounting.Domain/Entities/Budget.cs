using System.Collections.Generic;

namespace PersonalAccounting.Domain.Entities
{
    public class Budget : BaseEntity
    {
        public string Name { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
