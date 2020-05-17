using System;

namespace PersonalAccounting.Domain.Dto
{
    public class TransactionDto
    {
        public long Id { get; set; }
        public float Amount { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public long BudgetId { get; set; }
        public long CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
