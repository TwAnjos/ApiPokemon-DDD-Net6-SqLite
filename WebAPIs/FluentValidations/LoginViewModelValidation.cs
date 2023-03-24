using FluentValidation;
using WebAPIs.Models;

namespace WebAPIs.FluentValidations
{
    public class LoginViewModelValidation : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidation()
        {
            string regerEmail = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            RuleFor(u => u.email)
                .NotEmpty().WithMessage($"o campo email é Obrigatório.")
                .Matches(regerEmail).WithMessage($"o campo email não é valido.");

            RuleFor(u => u.senha)
                .NotEmpty().WithMessage($"o campo senha é Obrigatório.")
                .Must(u => u.Length >= 10 && u.Length <= 15).WithMessage($"o campo senha deve ser maior ou igual a 10 e menor ou igual a 15.");
        }
    }
}
