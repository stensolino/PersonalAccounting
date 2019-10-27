using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalAccounting.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public decimal MyProperty { get; set; }
        public int UserId { get; set; }
        //public ApplicationUser User { get; set; }
        public int ContoId { get; set; }
        public Conto Conto { get; set; }
    }
}
