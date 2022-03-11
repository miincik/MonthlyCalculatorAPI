using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Utilities.Results;
using MonthlyCalculatorAPI.Utilities.Security;

namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface ILoginService 
    {
        IDataResult<LoginResponseDTO> Authenticate(LoginDTO model);
        IDataResult<Account> findAccountById(int id);
    }
}
