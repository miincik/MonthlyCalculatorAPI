namespace MonthlyCalculatorAPI.Models.Entities.Expences
{
    public class Expence : IEntity
    {
        public int Id { get; set; }
        public decimal ExpenceAmount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ExpenceTypeId { get; set; }
        public ExpenceType ExpenceType { get; set; }
        public int ExpenceHistoryId { get; set; }
        public ExpenceHistory ExpenceHistory { get; set; }

    }
}
