using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Utilities.Results;
using IResult = MonthlyCalculatorAPI.Utilities.Results.IResult;

namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface IAccountService
    {
        IResult Add(Account account);
        IResult Delete(Account account);
        IResult Update(Account account);
        IDataResult<List<Account>> GetAll();
        IDataResult<Account> GetById(int accountId);
    }
}
