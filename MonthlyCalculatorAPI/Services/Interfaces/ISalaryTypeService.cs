using MonthlyCalculatorAPI.Models.Entities.Incomes;
using MonthlyCalculatorAPI.Utilities.Results;
using IResult = MonthlyCalculatorAPI.Utilities.Results.IResult;

namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface ISalaryTypeService
    {
        IResult Add(SalaryType salaryType);
        IResult Delete(SalaryType salaryType);
        IResult Update(SalaryType salaryType);
        IDataResult<List<SalaryType>> GetAll();
        IDataResult<SalaryType> GetById(int salaryTypeId);
    }
}
