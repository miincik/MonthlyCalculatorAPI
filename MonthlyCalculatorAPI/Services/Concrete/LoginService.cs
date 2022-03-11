using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;
using MonthlyCalculatorAPI.Services.Interfaces;
using MonthlyCalculatorAPI.Utilities.Results;
using MonthlyCalculatorAPI.Utilities.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static MonthlyCalculatorAPI.Utilities.Security.AppSettings;

namespace MonthlyCalculatorAPI.Services.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly AppSettings _appSettings;
        private readonly IAccountRepository _accountRepository;

        public LoginService(IOptions<AppSettings> appSettings, IAccountRepository accountRepository)
        {
            _appSettings = appSettings.Value;
            this._accountRepository = accountRepository;
        }

        public IDataResult<LoginResponseDTO> Authenticate(LoginDTO model)
        {
            var Account = _accountRepository.Get(e => e.Email == model.Email && e.Password == model.Password);
            if (Account == null) return null;
            var token = generateJwtToken(Account);

            return new SuccessDataResult<LoginResponseDTO>(token);
        }

        public IDataResult<Account> findAccountById(int id)
        {
            var result = _accountRepository.Get(e => e.Id == id);
            return new SuccessDataResult<Account>(result);
        }

        private string generateJwtToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", account.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
