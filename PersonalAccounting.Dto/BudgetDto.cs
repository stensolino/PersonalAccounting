using System.Collections.Generic;

namespace PersonalAccounting.Dto
{
    public class BudgetDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}
