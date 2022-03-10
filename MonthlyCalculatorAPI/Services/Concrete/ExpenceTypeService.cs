using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;
using MonthlyCalculatorAPI.Services.Interfaces;
using MonthlyCalculatorAPI.Utilities.Results;

namespace MonthlyCalculatorAPI.Services.Concrete
{
    public class ExpenceTypeService : IExpenceTypeService
    {
        private readonly IExpenceTypeRepository _expenceTypeRepository;

        public ExpenceTypeService(IExpenceTypeRepository expenceTypeRepository)
        {
            _expenceTypeRepository = expenceTypeRepository;
        }

        public Utilities.Results.IResult Add(ExpenceType expenceType)
        {
            var result = _expenceTypeRepository.Get(e => e.Id == expenceType.Id);
            if (result == null)
            {
                _expenceTypeRepository.Add(expenceType);
                return new SuccessResult("Gider tipi ekleme başarılı.");
            }
            
            return new ErrorResult("Eklenmeye çalışılan gider tipi zaten  mevcut");
        }

        public Utilities.Results.IResult Delete(ExpenceType expenceType)
        {
            var result = _expenceTypeRepository.Get(e => e.Id == expenceType.Id);
            if (result != null)
            {
                _expenceTypeRepository.Delete(expenceType);
                return new SuccessResult("Gider tipi silme başarılı.");
            }
            return new ErrorResult("Silinmeye çalışılan gider tipi mevcut değil");
        }

        public IDataResult<List<ExpenceType>> GetAll()
        {
            return new SuccessDataResult<List<ExpenceType>>(_expenceTypeRepository.GetAll());
        }

        public IDataResult<ExpenceType> GetById(int expenceTypeId)
        {
            return new SuccessDataResult<ExpenceType>(_expenceTypeRepository.Get(e => e.Id == expenceTypeId));
        }

        public Utilities.Results.IResult Update(ExpenceType expenceType)
        {
            var result = _expenceTypeRepository.Get(e => e.Id == expenceType.Id);
            if (result != null)
            {
                _expenceTypeRepository.Update(expenceType);
                return new SuccessResult("Gider tipi güncelleme başarılı.");
            }
            return new ErrorResult("Güncellenmeye çalışılan gider tipi mevcut değil");
        }
    }
}
