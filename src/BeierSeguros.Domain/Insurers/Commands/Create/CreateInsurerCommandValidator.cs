using FluentValidation;

namespace BeierSeguros.Domain.Insurers.Commands
{
    public class CreateInsurerCommandValidator : AbstractValidator<CreateInsurerCommand>
    {
        public CreateInsurerCommandValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório");

            RuleFor(a => a.Name)
                .MinimumLength(3)
                .WithMessage("O Nome deve conter no mínimo 3 caracteres");

            RuleFor(a => a.Name)
                .MaximumLength(120)
                .WithMessage("O Nome deve conter no máximo 120 caracteres");
        }
    }
}