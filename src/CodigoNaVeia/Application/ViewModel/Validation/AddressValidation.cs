using FluentValidation;

namespace Application.ViewModel.Validation
{
    public class AddressValidation : AbstractValidator<AddressViewModel>
    {
        public AddressValidation()
        {
            RuleFor(s => s.AddressComplement)
                .NotEmpty()
                .WithMessage("O campo Complemento deve ser preenchido")
                .Length(5, 50)
                .WithMessage("O campo Complemento deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(s => s.Number)
                .NotEmpty()
                .WithMessage("O campo Numero deve ser preenchido");

            RuleFor(s => s.PostalCode)
                .NotEmpty()
                .WithMessage("O campo CEP deve ser preenchido");

        }
    }
}