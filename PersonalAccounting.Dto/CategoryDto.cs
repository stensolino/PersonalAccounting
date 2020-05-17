using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalAccounting.Dto
{
    public class CategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float MaxAmount { get; set; }
        public string Description { get; set; }
        public long BudgetId { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}
