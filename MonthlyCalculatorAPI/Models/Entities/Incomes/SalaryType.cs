namespace MonthlyCalculatorAPI.Models.Entities.Incomes
{
    public class SalaryType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }

    }


}
