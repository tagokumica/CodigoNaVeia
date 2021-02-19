using FluentValidation;
using Infra.CrossCutting.Security.ViewModel;

namespace Infra.CrossCutting.Security.Validation
{
    public class ForgotPasswordValidation : AbstractValidator<ForgotPasswordViewModel>
    {
        public ForgotPasswordValidation()
        {
            RuleFor(s => s.Email).NotEmpty().WithMessage("Digite o Email").EmailAddress();


        }
    }
}