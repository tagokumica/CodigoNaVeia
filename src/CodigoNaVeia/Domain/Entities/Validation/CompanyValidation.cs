using Domain.Validate;
using FluentValidation;

namespace Domain.Entities.Validation
{
    public class CompanyValidation : AbstractValidator<Company>
    {
        public CompanyValidation()
        {
            RuleFor(s => CnpjValidate.Validate(s.Cnpj))
                .Equal(true)
                .WithMessage("O Cnpj esta invalido");



            RuleFor(s => IeValidate.Validate(s.Ie))
                .Equal(true)
                .WithMessage("O Inscrição Estadual esta invalido");

        }
    }
}