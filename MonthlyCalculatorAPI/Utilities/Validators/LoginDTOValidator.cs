using FluentValidation;
using static MonthlyCalculatorAPI.Utilities.Security.AppSettings;

namespace MonthlyCalculatorAPI.Utilities.Validators
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex).WithMessage("Email formati hatalıdır");
            RuleFor(x => x.Password).NotNull().WithMessage("Password kurallara düzgün bir şekilde oluşturulmalıdır.");
        }
    }
}
