using System;
using FluentValidation;

namespace BeierSeguros.Domain.Insurers.Commands
{
    public class UpdateInsurerCommandValidator : AbstractValidator<UpdateInsurerCommand>
    {
        public UpdateInsurerCommandValidator()
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