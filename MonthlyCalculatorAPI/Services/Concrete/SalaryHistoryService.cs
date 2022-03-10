using MonthlyCalculatorAPI.Models.Entities.Incomes;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;
using MonthlyCalculatorAPI.Services.Interfaces;
using MonthlyCalculatorAPI.Utilities.Results;

namespace MonthlyCalculatorAPI.Services.Concrete
{
    public class SalaryHistoryService : ISalaryHistoryService
    {
        private readonly ISalaryHistoryRepository _salaryHistoryRepository;

        public SalaryHistoryService(ISalaryHistoryRepository salaryHistoryRepository)
        {
            _salaryHistoryRepository = salaryHistoryRepository;
        }

        public Utilities.Results.IResult Add(SalaryHistory salaryHistory)
        {
            var result = _salaryHistoryRepository.Get(e => e.Id == salaryHistory.Id);
            if (result == null)
            {
                _salaryHistoryRepository.Add(salaryHistory);
                return new SuccessResult("Gelir ayrıntısı ekleme başarılı.");
            }

            return new ErrorResult("Eklenmeye çalışılan gelir ayrıntısı zaten mevcut");
        }

        public Utilities.Results.IResult Delete(SalaryHistory salaryHistory)
        {
            var result = _salaryHistoryRepository.Get(e => e.Id == salaryHistory.Id);
            if (result != null)
            {
                _salaryHistoryRepository.Delete(salaryHistory);
                return new SuccessResult("Gelir ayrıntısı silme başarılı.");
            }

            return new ErrorResult("Silinmeye çalışılan gelir ayrıntısı zaten mevcut değil");
        }

        public IDataResult<List<SalaryHistory>> GetAll()
        {
            return new SuccessDataResult<List<SalaryHistory>>(_salaryHistoryRepository.GetAll());
        }

        public IDataResult<SalaryHistory> GetById(int salaryHistoryId)
        {
            return new SuccessDataResult<SalaryHistory>(_salaryHistoryRepository.Get(e => e.Id == salaryHistoryId));
        }

        public Utilities.Results.IResult Update(SalaryHistory salaryHistory)
        {
            var result = _salaryHistoryRepository.Get(e => e.Id == salaryHistory.Id);
            if (result != null)
            {
                _salaryHistoryRepository.Update(salaryHistory);
                return new SuccessResult("Gelir ayrıntısı güncelleme başarılı.");
            }

            return new ErrorResult("Güncellenmeye çalışılan gelir ayrıntısı mevcut değil");
        }
    }
}
