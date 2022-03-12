namespace MonthlyCalculatorAPI.Models.Entities.Expences
{
    public class ExpenceHistory : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Expence> Expences { get; set; }
    }
}
