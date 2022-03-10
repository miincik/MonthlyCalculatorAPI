using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;
using MonthlyCalculatorAPI.Services.Interfaces;
using MonthlyCalculatorAPI.Utilities.Results;

namespace MonthlyCalculatorAPI.Services.Concrete
{
    public class ExpenceHistoryService : IExpenceHistoryService
    {
        private readonly IExpenceHistoryRepository _expenceHistoryRepository;

        public ExpenceHistoryService(IExpenceHistoryRepository expenceHistoryRepository)
        {
            _expenceHistoryRepository = expenceHistoryRepository;
        }

        public Utilities.Results.IResult Add(ExpenceHistory expenceHistory)
        {
            var result = _expenceHistoryRepository.Get(e => e.Id == expenceHistory.Id);
            if (result == null)
            {
                _expenceHistoryRepository.Add(expenceHistory);
                return new SuccessResult("Gider ayrıntıları ekleme başarılı.");
            }
           
            return new ErrorResult("Eklenmeye çalışılan gider ayrıntıları zaten  mevcut");
        }

        public Utilities.Results.IResult Delete(ExpenceHistory expenceHistory)
        {
            var result = _expenceHistoryRepository.Get(e => e.Id == expenceHistory.Id);
            if (result != null)
            {
                _expenceHistoryRepository.Delete(expenceHistory);
                return new SuccessResult("Gider ayrıntıları silme başarılı.");
            }
            
            return new ErrorResult("Silinmeye çalışılan gider ayrıntıları mevcut değildir");
        }

        public IDataResult<List<ExpenceHistory>> GetAll()
        {
            return new SuccessDataResult<List<ExpenceHistory>>(_expenceHistoryRepository.GetAll());
        }

        public IDataResult<ExpenceHistory> GetById(int expenceHistoryId)
        {
            return new SuccessDataResult<ExpenceHistory>(_expenceHistoryRepository.Get(e => e.Id == expenceHistoryId));
        }

        public Utilities.Results.IResult Update(ExpenceHistory expenceHistory)
        {
            var result = _expenceHistoryRepository.Get(e => e.Id == expenceHistory.Id);
            if (result != null)
            {
                _expenceHistoryRepository.Update(expenceHistory);
                return new SuccessResult("Gider ayrıntıları güncelleme başarılı.");
            }
            return new ErrorResult("Güncellenmeye çalışılan gider ayrıntıları mevcut değildir");
        }
    }
}
