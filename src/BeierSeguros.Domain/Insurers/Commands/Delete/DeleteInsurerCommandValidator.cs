using System;
using FluentValidation;

namespace BeierSeguros.Domain.Insurers.Commands
{
    public class DeleteInsurerCommandValidator : AbstractValidator<DeleteInsurerCommand>
    {
        public DeleteInsurerCommandValidator()
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