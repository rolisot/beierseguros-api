using FluentValidation;

namespace BeierSeguros.Domain.Cities.Commands
{
    public class CreateCityValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                .MinimumLength(3).WithMessage("{PropertyName} deve conter no mínimo {MinLength} caracteres")
                .MaximumLength(120).WithMessage("{PropertyName} deve conter no máximo {MaxLength} caracteres");

            RuleFor(a => a.State)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                .MinimumLength(2).WithMessage("{PropertyName} deve conter no mínimo {MinLength} caracteres")
                .MaximumLength(2).WithMessage("{PropertyName} deve conter no máximo {MaxLength} caracteres");
        }
    }
}