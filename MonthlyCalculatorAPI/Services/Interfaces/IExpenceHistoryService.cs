using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Utilities.Results;

namespace MonthlyCalculatorAPI.Services.Interfaces

{
    public interface IExpenceHistoryService : IServiceBase<ExpenceHistory>
    {
        IDataResult<List<ExpenceHistory>> GetAll();
        IDataResult<ExpenceHistory> GetById(int expenceHistoryId);
    }
}
