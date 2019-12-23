using System;
using FluentValidation;

namespace BeierSeguros.Domain.CarWorkshops.Commands
{
    public class UpdateCarWorkshopCommandValidator : AbstractValidator<UpdateCarWorkshopCommand>
    {
        public UpdateCarWorkshopCommandValidator()
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

            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório");

            RuleFor(a => a.Name)
                .MinimumLength(3)
                .WithMessage("O Nome deve conter no mínimo 3 caracteres");

            RuleFor(a => a.Name)
                .MaximumLength(120)
                .WithMessage("O Nome deve conter no máximo 120 caracteres");

            RuleFor(a => a.Address)
                .NotEmpty()
                .WithMessage("O Endereço é obrigatório");

            RuleFor(a => a.Address)
                .MinimumLength(3)
                .WithMessage("O Endereço deve conter no mínimo 3 caracteres");

            RuleFor(a => a.Name)
                .MaximumLength(120)
                .WithMessage("O Endereço deve conter no máximo 120 caracteres");

            RuleFor(a => a.Phone)
                .NotEmpty()
                .WithMessage("O Telefone é obrigatório");

            RuleFor(a => a.Phone)
                .MaximumLength(14)
                .WithMessage("O Telefone deve conter no máximo 14 caracteres");

            RuleFor(a => a.CityId)
                .NotEmpty()
                .WithMessage("O campo CityId é obrigatório");

            RuleFor(a => a.CityId.ToString())
                .Length(36)
                .WithMessage("O campo CityId é inválido");

            RuleFor(a => a.CityId)
                .NotEqual(Guid.Empty)
                .WithMessage("O campo CityId é inválido");
        }
    }
}