namespace MonthlyCalculatorAPI.Models.Entities.Incomes
{
    public class Salary : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SalaryAmount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SalaryTypeId { get; set; }
        public SalaryType SalaryType { get; set; }
        public int SalaryHistoryId { get; set; }
        public SalaryHistory SalaryHistory { get; set; }

    }


}
