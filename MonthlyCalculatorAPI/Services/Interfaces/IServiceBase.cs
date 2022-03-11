using IResult = MonthlyCalculatorAPI.Utilities.Results.IResult;

namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface IServiceBase<T>
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
    }
}
