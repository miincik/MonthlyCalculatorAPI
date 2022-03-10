using MonthlyCalculatorAPI.Models.Entities.Incomes;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;
using MonthlyCalculatorAPI.Services.Interfaces;
using MonthlyCalculatorAPI.Utilities.Results;

namespace MonthlyCalculatorAPI.Services.Concrete
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _salaryRepository;

        public SalaryService(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        public Utilities.Results.IResult Add(Salary salary)
        {
            var result = _salaryRepository.Get(e => e.Id == salary.Id);
            if (result == null)
            {
                _salaryRepository.Add(salary);
                return new SuccessResult("Gelir ekleme başarılı.");
            }
            
            return new ErrorResult("Eklenmeye çalışılan gelir zaten mevcut");
        }

        public Utilities.Results.IResult Delete(Salary salary)
        {
            var result = _salaryRepository.Get(e => e.Id == salary.Id);
            if (result != null)
            {
                _salaryRepository.Delete(salary);
                return new SuccessResult("Gelir silme başarılı.");
            }
            
            return new ErrorResult("Silinmeye çalışılan gelir zaten mevcut değil");
        }

        public IDataResult<List<Salary>> GetAll()
        {
            return new SuccessDataResult<List<Salary>>(_salaryRepository.GetAll());
        }

        public IDataResult<List<Salary>> GetAllSalaryAmountByASC(decimal amount)
        {
            return new SuccessDataResult<List<Salary>>(_salaryRepository.GetAll(e=>e.SalaryAmount == amount));
        }

        public IDataResult<List<Salary>> GetAllSalaryAmountByDes(decimal amount)
        {
            return new SuccessDataResult<List<Salary>>(_salaryRepository.GetAll(e => e.SalaryAmount == amount));
        }

        public IDataResult<List<Salary>> GetAllSalaryBetweenValues(decimal minValue, decimal maxValue)
        {
            return new SuccessDataResult<List<Salary>>(_salaryRepository.GetAll(e => e.SalaryAmount <= minValue && e.SalaryAmount >=maxValue));
        }

        public IDataResult<List<Salary>> GetAllSalaryByTypeName(string typeName)
        {
            return new SuccessDataResult<List<Salary>>(_salaryRepository.GetAll(e => e.SalaryType.Name == typeName));
        }

        public IDataResult<Salary> GetByHistoryId(int historyId)
        {
            return new SuccessDataResult<Salary>(_salaryRepository.Get(e=>e.SalaryHistoryId == historyId));
        }

        public IDataResult<Salary> GetById(int salaryId)
        {
            return new SuccessDataResult<Salary>(_salaryRepository.Get(e => e.Id == salaryId));
        }

        public IDataResult<Salary> GetByTypeId(int typeId)
        {
            return new SuccessDataResult<Salary>(_salaryRepository.Get(e => e.SalaryTypeId == typeId));
        }

        public Utilities.Results.IResult Update(Salary salary)
        {
            var result = _salaryRepository.Get(e => e.Id == salary.Id);
            if (result != null)
            {
                _salaryRepository.Update(salary);
                return new SuccessResult("Gelir güncelleme başarılı.");
            }
            return new ErrorResult("Güncellenmeye çalışılan gelir mevcut değil");
        }
    }
}
