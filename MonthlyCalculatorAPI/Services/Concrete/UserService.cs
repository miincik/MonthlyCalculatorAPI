using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;
using MonthlyCalculatorAPI.Services.Interfaces;
using MonthlyCalculatorAPI.Utilities.Results;

namespace MonthlyCalculatorAPI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Utilities.Results.IResult Add(User user)
        {
            var result = _userRepository.Get(e => e.Email == user.Email);
            if (result == null)
            {
                _userRepository.Add(user);
                return new SuccessResult("Kullanıcı ekleme başarılı.");
            }

            return new ErrorResult("Eklenmeye çalışılan kullanıcı zaten  mevcut");
        }
    

        public Utilities.Results.IResult Delete(User user)
        {
        var result = _userRepository.Get(e => e.Id == user.Id);
        if (result != null)
        {
            _userRepository.Delete(user);
            return new SuccessResult("Kullanıcı silme başarılı.");
        }

        return new ErrorResult("Silinmeye çalışılan kullanıcı zaten mevcut değil");
        }   

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userRepository.GetAll());
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userRepository.Get(e=>e.Id == userId));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userRepository.Get(e=>e.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userRepository.GetClaims(user));
        }

        public Utilities.Results.IResult Update(User user)
        {
            var result = _userRepository.Get(e => e.Id == user.Id);
            if (result != null)
            {
                _userRepository.Update(user);
                return new SuccessResult("Kullanıcı güncelleme başarılı.");
            }

            return new ErrorResult("Güncellenmeye çalışılan kullanıcı mevcut değil");
        }
    }
}
