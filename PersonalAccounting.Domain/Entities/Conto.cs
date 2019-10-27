namespace PersonalAccounting.Domain.Entities
{
    public class Conto : BaseEntity
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
