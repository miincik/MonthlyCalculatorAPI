using MonthlyCalculatorAPI.Models.Entities.Incomes;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;
using MonthlyCalculatorAPI.Services.Interfaces;
using MonthlyCalculatorAPI.Utilities.Results;

namespace MonthlyCalculatorAPI.Services.Concrete
{
    public class SalaryTypeService : ISalaryTypeService
    {
        private readonly ISalaryTypeRepository _salaryTypeRepository;

        public SalaryTypeService(ISalaryTypeRepository salaryTypeRepository)
        {
            _salaryTypeRepository = salaryTypeRepository;
        }

        public Utilities.Results.IResult Add(SalaryType salaryType)
        {
            var result = _salaryTypeRepository.Get(e => e.Id == salaryType.Id);
            if (result == null)
            {
                _salaryTypeRepository.Add(salaryType);
                return new SuccessResult("Gelir tipi ekleme başarılı.");
            }

            return new ErrorResult("Eklenmeye çalışılan gelir tipi zaten mevcut");
        }

        public Utilities.Results.IResult Delete(SalaryType salaryType)
        {
            var result = _salaryTypeRepository.Get(e => e.Id == salaryType.Id);
            if (result != null)
            {
                _salaryTypeRepository.Delete(salaryType);
                return new SuccessResult("Gelir tipi silme başarılı.");
            }

            return new ErrorResult("Silinmeye çalışılan gelir tipi zaten mevcut değil");
        }

        public IDataResult<List<SalaryType>> GetAll()
        {
            return new SuccessDataResult<List<SalaryType>>(_salaryTypeRepository.GetAll());
        }

        public IDataResult<SalaryType> GetById(int salaryTypeId)
        {
            return new SuccessDataResult<SalaryType>(_salaryTypeRepository.Get(e => e.Id == salaryTypeId));
        }

        public Utilities.Results.IResult Update(SalaryType salaryType)
        {
            var result = _salaryTypeRepository.Get(e => e.Id == salaryType.Id);
            if (result == null)
            {
                _salaryTypeRepository.Update(salaryType);
                return new SuccessResult("Gelir tipi güncelleme başarılı.");
            }

            return new ErrorResult("Güncellemeye çalışılan gelir tipi mevcut değil");
        }
    }
}
