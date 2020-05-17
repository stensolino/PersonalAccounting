using System;

namespace PersonalAccounting.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public float Amount { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public long BudgetId { get; set; }
        public Budget Budget { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
