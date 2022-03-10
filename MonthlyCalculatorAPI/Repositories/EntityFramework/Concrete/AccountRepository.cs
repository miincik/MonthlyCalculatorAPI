using MonthlyCalculatorAPI.Contexts;
using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Base;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;

namespace MonthlyCalculatorAPI.Repositories.EntityFramework.Concrete
{
    public class AccountRepository : EfEntityRepositoryBase<Account, MonthlyCalculatorDbContext>, IAccountRepository
    {
        /* private readonly MonthlyCalculatorDbContext _context;
         public AccountRepository(MonthlyCalculatorDbContext context)
         {
             _context = context;
         }
         public Account FindAccountByEmailAndPassword(LoginDTO loginDTO)
         {
             Account accountFinded = (from x in _context.Account
                                      where x.Email == loginDTO.Email && x.Password == loginDTO.Password
                                      select x).FirstOrDefault();
             return accountFinded;
         }

         public Account findAccountById(int id)
         {
             throw new NotImplementedException();
         }*/
    }
}
