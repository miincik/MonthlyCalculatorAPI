using MonthlyCalculatorAPI.Models.Entities;

namespace MonthlyCalculatorAPI.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
