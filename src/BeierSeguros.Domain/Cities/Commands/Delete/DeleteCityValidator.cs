using System;
using FluentValidation;

namespace BeierSeguros.Domain.Cities.Commands
{
    public class DeleteCityValidator : AbstractValidator<DeleteCityCommand>
    {
        public DeleteCityValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty()
                .WithMessage("O Id é obrigatório");

            RuleFor(a => a.Id.ToString())
                .Length(36)
                .WithMessage("O Id é inválido");

            RuleFor(a => a.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("O Id é inválido");
        }
    }
}