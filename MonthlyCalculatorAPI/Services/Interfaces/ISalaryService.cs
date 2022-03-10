using MonthlyCalculatorAPI.Models.Entities.Incomes;
using MonthlyCalculatorAPI.Utilities.Results;
using IResult = MonthlyCalculatorAPI.Utilities.Results.IResult;

namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface ISalaryService
    {
        IResult Add(Salary salary);
        IResult Delete(Salary salary);
        IResult Update(Salary salary);
        IDataResult<List<Salary>> GetAll();
        IDataResult<Salary> GetById(int salaryId);
        IDataResult<Salary> GetByTypeId(int typeId);
        IDataResult<Salary> GetByHistoryId(int historyId);
        IDataResult<List<Salary>> GetAllSalaryAmountByDes(decimal amount);
        IDataResult<List<Salary>> GetAllSalaryAmountByASC(decimal amount);
        IDataResult<List<Salary>> GetAllSalaryByTypeName(string typeName);
        IDataResult<List<Salary>> GetAllSalaryByHistoryName(string historyName);
        IDataResult<List<Salary>> GetAllSalaryBetweenValues(decimal minValue, decimal maxValue);
    }
}
