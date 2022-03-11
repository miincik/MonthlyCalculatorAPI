using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Utilities.Results;

namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface IExpenceService : IServiceBase<Expence>
    {
        IDataResult<List<Expence>> GetAll();
        IDataResult<Expence> GetById(int expenceId);
        IDataResult<Expence> GetByTypeId(int typeId);
        IDataResult<Expence> GetByHistoryId(int historyId);
        IDataResult<List<Expence>> GetAllExpenceAmountByDes(decimal amount);
        IDataResult<List<Expence>> GetAllExpenceAmountByASC(decimal amount);
        IDataResult<List<Expence>> GetAllExpenceByTypeName(string typeName);
        IDataResult<List<Expence>> GetAllExpenceBetweenValues(decimal minValue, decimal maxValue);
       
    }
}
