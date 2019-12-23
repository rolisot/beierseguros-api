using FluentValidation;

namespace BeierSeguros.Domain.CarWorkshopsInsurers.Command
{
    public class DeleteCarWorkshopInsurerCommandValidator : AbstractValidator<DeleteCarWorkshopInsurerCommand>
    {
        public DeleteCarWorkshopInsurerCommandValidator()
        {
            RuleFor(a => a.CarWorkshopId.ToString())
                            .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                            .MinimumLength(36).WithMessage("{PropertyName} deve conter {MinLength} caracteres")
                            .MaximumLength(36).WithMessage("{PropertyName} deve conter {MaxLength} caracteres");

            RuleFor(a => a.CarWorkshopInsurerId.ToString())
                .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                .MinimumLength(36).WithMessage("{PropertyName} deve conter {MinLength} caracteres")
                .MaximumLength(36).WithMessage("{PropertyName} deve conter {MaxLength} caracteres");
        }
    }
}