using MonthlyCalculatorAPI.Contexts;
using MonthlyCalculatorAPI.Models.Entities.Incomes;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Base;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;

namespace MonthlyCalculatorAPI.Repositories.EntityFramework.Concrete
{
    public class SalaryHistoryRepository : EfEntityRepositoryBase<SalaryHistory, MonthlyCalculatorDbContext>, ISalaryHistoryRepository
    {
    }
}
