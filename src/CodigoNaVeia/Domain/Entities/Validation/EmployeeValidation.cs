using Domain.Validate;
using FluentValidation;

namespace Domain.Entities.Validation
{
    public class EmployeeValidation : AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(s => CpfValidate.Validate(s.Cpf))
                .Equal(true)
                .WithMessage("O Cpf esta invalido");


            RuleFor(s => RgValidate.Validate(s.Rg))
                .Equal(true)
                .WithMessage("O Rg esta invalido");
        }
    }
}