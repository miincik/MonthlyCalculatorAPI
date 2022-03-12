namespace MonthlyCalculatorAPI.Models.Entities
{
    public class Gender : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
    }
}
