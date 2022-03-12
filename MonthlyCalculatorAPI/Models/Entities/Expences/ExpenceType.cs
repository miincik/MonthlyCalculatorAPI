namespace MonthlyCalculatorAPI.Models.Entities.Expences
{
    public class ExpenceType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Expence> Expences { get; set; }

    }
}
