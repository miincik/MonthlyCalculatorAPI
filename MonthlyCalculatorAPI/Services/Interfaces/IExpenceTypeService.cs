using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Utilities.Results;

namespace MonthlyCalculatorAPI.Services.Interfaces

{
    public interface IExpenceTypeService : IServiceBase<ExpenceType>
    {
        IDataResult<List<ExpenceType>> GetAll();
        IDataResult<ExpenceType> GetById(int expenceTypeId);
    }
}
