using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Utilities.Results;

namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface IAccountService : IServiceBase<Account>
    {
        IDataResult<List<Account>> GetAll();
        IDataResult<Account> GetById(int accountId);
    }
}
