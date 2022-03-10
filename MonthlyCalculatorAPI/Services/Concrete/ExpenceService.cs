using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;
using MonthlyCalculatorAPI.Services.Interfaces;
using MonthlyCalculatorAPI.Utilities.Results;

namespace MonthlyCalculatorAPI.Services.Concrete
{
    public class ExpenceService : IExpenceService
    {
        private readonly IExpenceRepository _expenceRepository;

        public ExpenceService(IExpenceRepository expenceRepository)
        {
            _expenceRepository = expenceRepository;
        }

        public Utilities.Results.IResult Add(Expence expence)
        {
            var result = _expenceRepository.Get(e=>e.Id == expence.Id);
            if (result == null)
            {
                _expenceRepository.Add(expence);
                return new SuccessResult("Gider ekleme başarılı.");
            }
            return new ErrorResult("Eklenmeye çalışılan gider zaten mevcut");
        }

        public Utilities.Results.IResult Delete(Expence expence)
        {
            var result = _expenceRepository.Get(e => e.Id == expence.Id);
            if (result != null)
            {
                _expenceRepository.Delete(expence);
                return new SuccessResult("Gider silme başarılı.");
            }
            return new ErrorResult("Silinmeye çalışılan gider mevcut değil.");
        }

        public IDataResult<List<Expence>> GetAll()
        {
            return new SuccessDataResult<List<Expence>>(_expenceRepository.GetAll());
        }

        public IDataResult<List<Expence>> GetAllExpenceAmountByASC(decimal amount)
        {
            return new SuccessDataResult<List<Expence>>(_expenceRepository.GetAll(e=>e.ExpenceAmount == amount));
        }

        public IDataResult<List<Expence>> GetAllExpenceAmountByDes(decimal amount)
        {
            return new SuccessDataResult<List<Expence>>(_expenceRepository.GetAll(e => e.ExpenceAmount == amount));
        }

        public IDataResult<List<Expence>> GetAllExpenceBetweenValues(decimal minValue, decimal maxValue)
        {
            return new SuccessDataResult<List<Expence>>(_expenceRepository.GetAll(e => e.ExpenceAmount <= minValue && e.ExpenceAmount >= maxValue));
        }

        public IDataResult<List<Expence>> GetAllExpenceByTypeName(string typeName)
        {
            return new SuccessDataResult<List<Expence>>(_expenceRepository.GetAll(e => e.ExpenceType.Name == typeName));
        }

        public IDataResult<Expence> GetByHistoryId(int historyId)
        {
            return new SuccessDataResult<Expence>(_expenceRepository.Get(e => e.ExpenceHistoryId == historyId));
        }

        public IDataResult<Expence> GetById(int expenceId)
        {
            return new SuccessDataResult<Expence>(_expenceRepository.Get(e => e.Id == expenceId));

        }

        public IDataResult<Expence> GetByTypeId(int typeId)
        {
            return new SuccessDataResult<Expence>(_expenceRepository.Get(e => e.ExpenceTypeId == typeId));
        }

        public Utilities.Results.IResult Update(Expence expence)
        {
            var result = _expenceRepository.Get(e => e.Id == expence.Id);
            if (result != null)
            {
                _expenceRepository.Update(expence);
                return new SuccessResult("Gider Güncelleme başarılı.");
            }
            return new ErrorResult("Güncellenmeye çalışılan gider mevcut değil.");
            
        }
    }
}
