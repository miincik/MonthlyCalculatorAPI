using MonthlyCalculatorAPI.Contexts;
using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Base;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;

namespace MonthlyCalculatorAPI.Repositories.EntityFramework.Concrete
{
    public class ExpenceRepository : EfEntityRepositoryBase<Expence, MonthlyCalculatorDbContext>, IExpenceRepository
    {
    }
}
