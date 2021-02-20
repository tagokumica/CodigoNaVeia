using FluentValidation;

namespace Application.ViewModel.Validation
{
    public class EmployeeValidation: AbstractValidator<EmployeeViewModel>
    {
        public EmployeeValidation()
        {
            
            
            
            RuleFor(s => s.Name)
                .NotEmpty()
                .WithMessage("O campo Nome deve ser preenchido")
                .Length(5, 50)
                .WithMessage("O campo Nome deve ter entre {MinLength} e {MaxLength} caracteres")
                .Matches(@"^[a-zA-Z''-'\s]{1,40}$")
                .WithMessage("Números e caracteres especiais não são permitidos no Nome.");



            RuleFor(s => s.Email)
                .NotEmpty()
                .WithMessage("Email deve ser preenchido")
                .Length(5, 40)
                .WithMessage("O campo Nome deve ter entre {MinLength} e {MaxLength} caracteres")
                .EmailAddress()
                .WithMessage("A validação Email é requirida");



            RuleFor(s => s.Cpf)
                .NotEmpty()
                .WithMessage("O campo Cpf deve ser preenchido")
                .MaximumLength(11)
                .WithMessage("O campo Cpf deve ter no {MaxLength} caracteres");



            RuleFor(s => s.Rg)
                .NotEmpty()
                .WithMessage("O campo Rg deve ser preenchido")
                .Length(9, 11)
                .WithMessage("O campo Rg deve ter entre {MinLenght} e no {MaxLength} caracteres");





        }
    }
}