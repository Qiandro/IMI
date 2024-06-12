using FluentValidation;
using Imi.Project.Api.Core.Dtos.Accounts;

namespace Pri.IdentityDemo.Api.Validators
{
    public class LoginValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Email).EmailAddress().NotEmpty().WithMessage("Gelieve een e-mailadres in te geven");
            RuleFor(l => l.Password).NotEmpty().WithMessage("Gelieve pwd op te geven");
        }
    }
}
