using Domain.ValueObject;
using FluentValidation;

namespace Domain.Entities.Validation
{
    public class EmployeeValidation : AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(s => Cpf.Validate(s.Cpf))
                .Equal(true)
                .WithMessage("O Cpf esta invalido");


            RuleFor(s => Rg.Validate(s.Rg))
                .Equal(true)
                .WithMessage("O Rg esta invalido");
        }
    }
}