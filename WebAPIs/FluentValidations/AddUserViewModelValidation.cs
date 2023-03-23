using FluentValidation;
using WebAPIs.Models;

namespace WebAPIs.FluentValidations
{
    public class AddUserViewModelValidation : AbstractValidator<AddUserViewModel>
    {
        public AddUserViewModelValidation()
        {
            string regerEmail = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            RuleFor(v => v.email)
                .NotEmpty().WithMessage($"o campo email é Obrigatório.")
                .Matches(regerEmail).WithMessage($"o campo email não é valido."); ;

            RuleFor(v => v.DtNascimento).NotEmpty()
                .NotEmpty().WithMessage($"o campo DtNascimento é Obrigatório.")
                .LessThan(DateTime.Now).WithMessage($"o campo DtNascimento precisa ser menor que hoje.");

            RuleFor(v => v.senha)
                .NotEmpty().WithMessage($"o campo senha é Obrigatório.")
                .Must(v => v.Length >= 10 && v.Length <= 15).WithMessage($"o campo senha deve ser maior ou igual a 10 e menor ou igual a 15.");
        }
    }
}
