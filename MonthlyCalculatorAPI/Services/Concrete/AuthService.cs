using MonthlyCalculatorAPI.Models.DTOs;
using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Services.Interfaces;
using MonthlyCalculatorAPI.Utilities.Logger;
using MonthlyCalculatorAPI.Utilities.Results;
using MonthlyCalculatorAPI.Utilities.Security.JWT;
using IResult = MonthlyCalculatorAPI.Utilities.Results.IResult;

namespace MonthlyCalculatorAPI.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthService(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsBlocked = false 
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kullanıcı kayıt edildi.");
        }

        [LogAspect(typeof(FileLogger))]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı mevcut değil.");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>("Kullanıcı şifresi hatalı.");
            }

            return new SuccessDataResult<User>(userToCheck.Data, "Giriş başarılı");
        }

        public IResult UserExists(string email)
        {
            var result = _userService.GetByMail(email);
            if (result != null)
            {
                return new ErrorResult("Kullanıcı zaten mevcut.");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, "AccessToken oluşturuldu.");
        }
    }
}
