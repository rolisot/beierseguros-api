using FluentValidation;

namespace BeierSeguros.Domain.CarWorkshopsInsurers.Command
{
    public class CreateCarWorkshopInsurerCommandValidator : AbstractValidator<CreateCarWorkshopInsurerCommand>
    {
        public CreateCarWorkshopInsurerCommandValidator()
        {
            RuleFor(a => a.InsurerId.ToString())
                .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                .MinimumLength(36).WithMessage("{PropertyName} deve conter {MinLength} caracteres")
                .MaximumLength(36).WithMessage("{PropertyName} deve conter {MaxLength} caracteres");

            RuleFor(a => a.CarWorkShopId.ToString())
                .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                .MinimumLength(36).WithMessage("{PropertyName} deve conter {MinLength} caracteres")
                .MaximumLength(36).WithMessage("{PropertyName} deve conter {MaxLength} caracteres");
        }
    }
}