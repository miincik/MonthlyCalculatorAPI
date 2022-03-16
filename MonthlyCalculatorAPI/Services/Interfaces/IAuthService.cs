using MonthlyCalculatorAPI.Models.DTOs;
using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Utilities.Results;
using MonthlyCalculatorAPI.Utilities.Security.JWT;
using IResult = MonthlyCalculatorAPI.Utilities.Results.IResult;

namespace MonthlyCalculatorAPI.Services.Interfaces
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
