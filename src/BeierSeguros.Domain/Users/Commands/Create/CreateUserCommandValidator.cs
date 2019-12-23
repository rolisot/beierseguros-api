using FluentValidation;

namespace BeierSeguros.Domain.Users.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("O {PropertyName} é obrigatório")
                .MinimumLength(3).WithMessage("O {PropertyName} deve conter no mínimo {MinLength} caracteres")
                .MaximumLength(120).WithMessage("O {PropertyName} deve conter no máximo {MaxLength} caracteres");

            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("O {PropertyName} é obrigatório")
                .MinimumLength(5).WithMessage("O {PropertyName} deve conter no mínimo {MinLength} caracteres")
                .MaximumLength(60).WithMessage("O {PropertyName} deve conter no máximo {MaxLength} caracteres");

            RuleFor(a => a.Password)
                .NotEmpty().WithMessage("O {PropertyName} é obrigatório")
                .MinimumLength(6).WithMessage("O {PropertyName} deve conter no mínimo {MinLength} caracteres")
                .MaximumLength(10).WithMessage("O {PropertyName} deve conter no máximo {MaxLength} caracteres");
        }
    }
}