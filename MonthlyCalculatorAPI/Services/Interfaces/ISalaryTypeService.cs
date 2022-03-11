using MonthlyCalculatorAPI.Models.Entities.Incomes;
using MonthlyCalculatorAPI.Utilities.Results;


namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface ISalaryTypeService : IServiceBase<SalaryType>
    {
        IDataResult<List<SalaryType>> GetAll();
        IDataResult<SalaryType> GetById(int salaryTypeId);
    }
}
