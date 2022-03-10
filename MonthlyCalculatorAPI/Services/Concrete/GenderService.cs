using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;
using MonthlyCalculatorAPI.Services.Interfaces;
using MonthlyCalculatorAPI.Utilities.Results;

namespace MonthlyCalculatorAPI.Services.Concrete
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public Utilities.Results.IResult Add(Gender gender)
        {
            var result = _genderRepository.Get(e => e.Name == gender.Name);
            if (result == null)
            {
                _genderRepository.Add(gender);
                return new SuccessResult("Cinsiyet ekleme başarılı.");
            }
            
            return new ErrorResult("Eklenmeye çalışılan cinsiyet zaten  mevcut");
        }

        public Utilities.Results.IResult Delete(Gender gender)
        {
            var result = _genderRepository.Get(e => e.Id == gender.Id);
            if (result != null)
            {
                _genderRepository.Delete(gender);
                return new SuccessResult("Cinsiyet silme başarılı.");
            }
            
            return new ErrorResult("Silinmeye çalışılan cinsiyet zaten mevcut değil.");
        }

        public IDataResult<List<Gender>> GetAll()
        {
            return new SuccessDataResult<List<Gender>>(_genderRepository.GetAll());
        }

        public IDataResult<Gender> GetById(int genderId)
        {
            return new SuccessDataResult<Gender>(_genderRepository.Get(e => e.Id == genderId));
        }

        public Utilities.Results.IResult Update(Gender gender)
        {
            var result = _genderRepository.Get(e => e.Id == gender.Id);
            if (result != null)
            {
                _genderRepository.Update(gender);
                return new SuccessResult("Cinsiyet güncelleme başarılı.");
            }
            
            return new ErrorResult("Güncellenmeye çalışılan cinsiyet mevcut değil");
        }
    }
}
