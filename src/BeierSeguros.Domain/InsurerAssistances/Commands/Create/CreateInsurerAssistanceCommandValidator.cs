using FluentValidation;

namespace BeierSeguros.Domain.InsurerAssistances.Commands
{
    public class CreateInsurerAssistanceCommandValidator : AbstractValidator<CreateInsurerAssistanceCommand>
    {
        public CreateInsurerAssistanceCommandValidator()
        {
            RuleFor(a => a.Phone)
                 .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                 .MinimumLength(11).WithMessage("{PropertyName} deve conter {MinLength} caracteres")
                 .MaximumLength(11).WithMessage("{PropertyName} deve conter {MaxLength} caracteres");

            RuleFor(a => a.InsurerId.ToString())
                .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                .MinimumLength(36).WithMessage("{PropertyName} deve conter {MinLength} caracteres")
                .MaximumLength(36).WithMessage("{PropertyName} deve conter {MaxLength} caracteres");

            // RuleFor(a => a.AssistancePhoneType.ToString())
            //     .NotEmpty().WithMessage("{PropertyName} é obrigatório")
            //     .MinimumLength(1).WithMessage("{PropertyName} deve conter {MinLength} caracteres")
            //     .MaximumLength(1).WithMessage("{PropertyName} deve conter {MaxLength} caracteres");

        }
    }
}