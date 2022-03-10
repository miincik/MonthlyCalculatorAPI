using MonthlyCalculatorAPI.Models.Entities.Incomes;
using MonthlyCalculatorAPI.Utilities.Results;
using IResult = MonthlyCalculatorAPI.Utilities.Results.IResult;

namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface ISalaryHistoryService
    {
        IResult Add(SalaryHistory salaryHistory);
        IResult Delete(SalaryHistory salaryHistory);
        IResult Update(SalaryHistory salaryHistory);
        IDataResult<List<SalaryHistory>> GetAll();
        IDataResult<SalaryHistory> GetById(int salaryHistoryId);
    }
}
