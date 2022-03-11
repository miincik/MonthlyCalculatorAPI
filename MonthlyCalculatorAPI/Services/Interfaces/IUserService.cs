using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Utilities.Results;

namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface IUserService : IServiceBase<User>
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
    }
}
