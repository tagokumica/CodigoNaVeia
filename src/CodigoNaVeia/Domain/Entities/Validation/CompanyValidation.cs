using Domain.ValueObject;
using FluentValidation;

namespace Domain.Entities.Validation
{
    public class CompanyValidation : AbstractValidator<Company>
    {
        public CompanyValidation()
        {
            RuleFor(s => Cnpj.Validate(s.Cnpj))
                .Equal(true)
                .WithMessage("O Cnpj esta invalido");



            RuleFor(s => Ie.Validate(s.Ie))
                .Equal(true)
                .WithMessage("O Inscrição Estadual esta invalido");

        }
    }
}