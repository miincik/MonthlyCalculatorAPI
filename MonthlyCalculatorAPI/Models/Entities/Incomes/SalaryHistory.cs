namespace MonthlyCalculatorAPI.Models.Entities.Incomes
{
    public class SalaryHistory : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
    }


}
