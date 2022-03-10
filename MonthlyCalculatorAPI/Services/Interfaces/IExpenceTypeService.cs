using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Utilities.Results;
using IResult = MonthlyCalculatorAPI.Utilities.Results.IResult;

namespace MonthlyCalculatorAPI.Services.Interfaces

{
    public interface IExpenceTypeService
    {
        IResult Add(ExpenceType expenceType);
        IResult Delete(ExpenceType expenceType);
        IResult Update(ExpenceType expenceType);
        IDataResult<List<ExpenceType>> GetAll();
        IDataResult<ExpenceType> GetById(int expenceTypeId);
    }
}
