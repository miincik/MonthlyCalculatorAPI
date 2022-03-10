using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Base;

namespace MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces
{
    public interface IExpenceRepository : IEntityRepository<Expence>
    {
    }
}
