using MonthlyCalculatorAPI.Models.Entities.Incomes;
using MonthlyCalculatorAPI.Utilities.Results;


namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface ISalaryHistoryService : IServiceBase<SalaryHistory>
    {
        IDataResult<List<SalaryHistory>> GetAll();
        IDataResult<SalaryHistory> GetById(int salaryHistoryId);
    }
}
