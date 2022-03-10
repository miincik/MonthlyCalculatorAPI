using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Utilities.Results;
using static MonthlyCalculatorAPI.Utilities.Security.AppSettings;

namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface ILoginService
    {
        IDataResult<LoginResponseDTO> Authenticate(LoginDTO model);
        IDataResult<Account> findAccountById(int id);
    }
}
