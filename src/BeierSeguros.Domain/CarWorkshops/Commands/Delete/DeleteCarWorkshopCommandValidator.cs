using System;
using FluentValidation;

namespace BeierSeguros.Domain.CarWorkshops.Commands
{
    public class DeleteCarWorkshopCommandValidator : AbstractValidator<DeleteCarWorkshopCommand>
    {
        public DeleteCarWorkshopCommandValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty()
                .WithMessage("O campo Id é obrigatório");

            RuleFor(a => a.Id.ToString())
                .Length(36)
                .WithMessage("O campo Id é inválido");

            RuleFor(a => a.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("O campo Id é inválido");
        }
    }
}