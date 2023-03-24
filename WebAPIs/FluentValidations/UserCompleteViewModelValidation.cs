using FluentValidation;
using WebAPIs.ViewModels;

namespace WebAPIs.FluentValidations
{
    public class UserCompleteViewModelValidation : AbstractValidator<UserCompleteViewModel>
    {
        public UserCompleteViewModelValidation()
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage($"o campo UserName é Obrigatório.");
            
            RuleFor(u => u.Email).NotEmpty().WithMessage($"o campo email é Obrigatório.");
            
            RuleFor(u => u.Senha).NotEmpty().WithMessage($"o campo Senha é Obrigatório.");
            
            RuleFor(u => u.DtNascimento).NotEmpty().WithMessage($"o campo DtNascimento é Obrigatório.")
                .LessThan(DateTime.Now).WithMessage($"o campo DtNascimento precisa ser menor que hoje."); ;
        }
    }
}