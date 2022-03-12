using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Models.Entities.Incomes;

namespace MonthlyCalculatorAPI.Models.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public virtual ICollection<Expence> Expences { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }


    }
}
