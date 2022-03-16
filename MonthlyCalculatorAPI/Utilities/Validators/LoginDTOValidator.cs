using FluentValidation;
using MonthlyCalculatorAPI.Models.DTOs;
using MonthlyCalculatorAPI.Utilities.Security;

namespace MonthlyCalculatorAPI.Utilities.Validators
{
    public class LoginDTOValidator : AbstractValidator<UserForLoginDto>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex).WithMessage("Email formati hatalıdır");
            RuleFor(x => x.Password).NotNull().WithMessage("Password kurallara düzgün bir şekilde oluşturulmalıdır.");
        }
    }
}
