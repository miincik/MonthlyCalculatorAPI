namespace MonthlyCalculatorAPI.Models.Entities
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
    }
}
