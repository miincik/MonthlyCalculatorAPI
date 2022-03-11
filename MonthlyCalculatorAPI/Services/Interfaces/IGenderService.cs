using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Utilities.Results;


namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface IGenderService : IServiceBase<Gender>
    {
        IDataResult<List<Gender>> GetAll();
        IDataResult<Gender> GetById(int genderId);
    }
}
