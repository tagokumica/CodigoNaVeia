using FluentValidation;
using Infra.CrossCutting.Security.ViewModel;

namespace Infra.CrossCutting.Security.Validation
{
    public class LoginValidation: AbstractValidator<LoginViewModel>
    {
        public LoginValidation()
        {
            RuleFor(s => s.Email).NotEmpty().WithMessage("Digite o Email").EmailAddress();

            RuleFor(s => s.Password).NotEmpty().WithMessage("Digite a Senha");

        }
    }
}