using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;
using MonthlyCalculatorAPI.Services.Interfaces;
using MonthlyCalculatorAPI.Utilities.Results;

namespace MonthlyCalculatorAPI.Services.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Utilities.Results.IResult Add(Account account)
        {
            var result = _accountRepository.Get(e => e.Email == account.Email);
            if (result == null)
            {
                _accountRepository.Add(account);
                return new SuccessResult("Üye ekleme başarılı.");
            }
            return new ErrorResult("Eklenmeye çalışılan üye zaten mevcut");
        }

        public Utilities.Results.IResult Delete(Account account)
        {
            var result = _accountRepository.Get(e => e.Email == account.Email);
            if (result != null)
            {
                _accountRepository.Delete(account);
                return new SuccessResult("Üye silme başarılı.");
            }
            
            return new ErrorResult("Silinmeye çalışılan üye zaten mevcut değil");
        }

        public IDataResult<List<Account>> GetAll()
        {
            return new SuccessDataResult<List<Account>>(_accountRepository.GetAll());
        }

        public IDataResult<Account> GetById(int accountId)
        {
            return new SuccessDataResult<Account>(_accountRepository.Get(e=>e.Id == accountId));
        }

        public Utilities.Results.IResult Update(Account account)
        {
            var result = _accountRepository.Get(e => e.Email == account.Email);
            if (result != null)
            {
                _accountRepository.Update(account);
                return new SuccessResult("Üye güncelleme başarılı.");
            }
            
            return new ErrorResult("Güncellenmeye çalışılan üye mevcut değil");
        }
    }
}
