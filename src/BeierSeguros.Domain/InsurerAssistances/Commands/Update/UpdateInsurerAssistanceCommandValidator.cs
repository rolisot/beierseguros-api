using FluentValidation;

namespace BeierSeguros.Domain.InsurerAssistances.Commands
{
    public class UpdateInsurerAssistanceCommandValidator : AbstractValidator<UpdateInsurerAssistanceCommand>
    {
        public UpdateInsurerAssistanceCommandValidator()
        {
            RuleFor(a => a.Phone)
                 .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                 .MinimumLength(11).WithMessage("{PropertyName} deve conter {MinLength} caracteres")
                 .MaximumLength(11).WithMessage("{PropertyName} deve conter {MaxLength} caracteres");

            RuleFor(a => a.Id.ToString())
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