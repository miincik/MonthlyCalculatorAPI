using MonthlyCalculatorAPI.Models.Entities.Incomes;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Base;

namespace MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces
{
    public interface ISalaryRepository : IEntityRepository<Salary>
    {
    }

}
