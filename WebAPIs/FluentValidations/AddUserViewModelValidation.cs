using FluentValidation;
using WebAPIs.Models;

namespace WebAPIs.FluentValidations
{
    public class AddUserViewModelValidation : AbstractValidator<AddUserViewModel>
    {
        public AddUserViewModelValidation()
        {
            string regerEmail = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            RuleFor(v => v.Email)
                .NotEmpty().WithMessage($"o campo email é Obrigatório.")
                .Matches(regerEmail).WithMessage($"o campo email não é valido.");

            RuleFor(v => v.Senha)
                .NotEmpty().WithMessage($"o campo senha é Obrigatório.")
                .Must(v => v.Length >= 6 && v.Length <= 10).WithMessage($"o campo senha deve ser maior ou igual a 6 e menor ou igual a 10.");

            RuleFor(v => v.CPF)
                .NotEmpty().WithMessage($"o campo email é Obrigatório.")
                .Matches("^[0-9]+$").WithMessage($"o campo cpf deve conter somente números"); ;


        }
    }
}
