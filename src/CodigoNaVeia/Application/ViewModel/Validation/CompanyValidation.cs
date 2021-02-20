using FluentValidation;

namespace Application.ViewModel.Validation
{
    public class CompanyValidation : AbstractValidator<CompanyViewModel>
    {
        public CompanyValidation()
        {

            RuleFor(s => s.Email)
                .NotEmpty()
                .WithMessage("Email deve ser preenchido")
                .Length(10, 40)
                .WithMessage("O campo Email deve ter entre {MinLength} e {MaxLength} caracteres")
                .EmailAddress()
                .WithMessage("A validação Email é requirida");


            RuleFor(s => s.Cnpj)
                .NotEmpty()
                .WithMessage("O campo Cnpj deve ser preenchido");


            RuleFor(s => s.Ie)
                .NotEmpty()
                .WithMessage("O campo Inscrição Estadual deve ser preenchido");


            RuleFor(s => s.Name)
                .NotEmpty()
                .WithMessage("O campo Nome do Proprietário deve ser preenchido")
                .Length(10, 50)
                .WithMessage("O campo Nome do Proprietário deve ter entre {MinLength} e {MaxLength} caracteres");



        }
    }
}