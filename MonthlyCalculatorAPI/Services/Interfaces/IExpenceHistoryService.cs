using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Utilities.Results;
using IResult = MonthlyCalculatorAPI.Utilities.Results.IResult;

namespace MonthlyCalculatorAPI.Services.Interfaces

{
    public interface IExpenceHistoryService
    {
        IResult Add(ExpenceHistory expenceHistory);
        IResult Delete(ExpenceHistory expenceHistory);
        IResult Update(ExpenceHistory expenceHistory);
        IDataResult<List<ExpenceHistory>> GetAll();
        IDataResult<ExpenceHistory> GetById(int expenceHistoryId);
    }
}
