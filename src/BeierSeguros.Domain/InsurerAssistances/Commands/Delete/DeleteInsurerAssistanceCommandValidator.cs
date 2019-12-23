using FluentValidation;

namespace BeierSeguros.Domain.InsurerAssistances.Commands
{
    public class DeleteInsurerAssistanceCommandValidator : AbstractValidator<DeleteInsurerAssistanceCommand>
    {
        public DeleteInsurerAssistanceCommandValidator()
        {
            RuleFor(a => a.Id.ToString())
                .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                .MinimumLength(36).WithMessage("{PropertyName} deve conter {MinLength} caracteres")
                .MaximumLength(36).WithMessage("{PropertyName} deve conter {MaxLength} caracteres");

            RuleFor(a => a.InsurerId.ToString())
                 .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                 .MinimumLength(36).WithMessage("{PropertyName} deve conter {MinLength} caracteres")
                 .MaximumLength(36).WithMessage("{PropertyName} deve conter {MaxLength} caracteres");
        }
    }
}