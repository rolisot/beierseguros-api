using System;
using BeierSeguros.Shared.Contracts;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.InsurerAssistances.Commands
{
    public class DeleteInsurerAssistanceCommand : ICommand, IRequest<Notifiable>
    {
        public Guid Id { get; set; }

        public Guid InsurerId { get; set; }

    }
}
