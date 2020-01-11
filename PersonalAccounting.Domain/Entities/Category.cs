using System.Collections.Generic;

namespace PersonalAccounting.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public float MaxAmount { get; set; }
        public string Description { get; set; }
        public int BudgetId { get; set; }
        public Budget Budget { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
