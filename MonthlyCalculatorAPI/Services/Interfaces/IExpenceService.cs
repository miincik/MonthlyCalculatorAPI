using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Utilities.Results;
using IResult = MonthlyCalculatorAPI.Utilities.Results.IResult;

namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface IExpenceService
    {
        IResult Add(Expence expence);
        IResult Delete(Expence expence);
        IResult Update(Expence expence);
        IDataResult<List<Expence>> GetAll();
        IDataResult<Expence> GetById(int expenceId);
        IDataResult<Expence> GetByTypeId(int typeId);
        IDataResult<Expence> GetByHistoryId(int historyId);
        IDataResult<List<Expence>> GetAllExpenceAmountByDes(decimal amount);
        IDataResult<List<Expence>> GetAllExpenceAmountByASC(decimal amount);
        IDataResult<List<Expence>> GetAllExpenceByTypeName(string typeName);
        IDataResult<List<Expence>> GetAllExpenceByHistoryName(string historyName);
        IDataResult<List<Expence>> GetAllExpenceBetweenValues(decimal minValue, decimal maxValue);
       
    }
}
