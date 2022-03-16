using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Models.Entities.Incomes;

namespace MonthlyCalculatorAPI.Models.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool IsBlocked { get; set; }

        public virtual ICollection<Expence> Expences { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
     


    }
}
