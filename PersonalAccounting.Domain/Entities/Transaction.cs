namespace PersonalAccounting.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public float Amount { get; set; }
        public string Note { get; set; }
        public int BudgetId { get; set; }
        public Budget Budget { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
