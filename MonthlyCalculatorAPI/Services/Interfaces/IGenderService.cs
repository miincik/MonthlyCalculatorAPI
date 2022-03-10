using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Utilities.Results;
using IResult = MonthlyCalculatorAPI.Utilities.Results.IResult;

namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface IGenderService
    {
        IResult Add(Gender gender);
        IResult Delete(Gender gender);
        IResult Update(Gender gender);
        IDataResult<List<Gender>> GetAll();
        IDataResult<Gender> GetById(int genderId);
    }
}
