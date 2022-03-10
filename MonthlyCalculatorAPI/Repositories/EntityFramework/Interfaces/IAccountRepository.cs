using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Base;

namespace MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces
{
    public interface IAccountRepository : IEntityRepository<Account>
    {
        //Account FindAccountByEmailAndPassword(LoginDTO loginDTO);
        //Account findAccountById(int id);
    }
}
