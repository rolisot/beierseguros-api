using System;
using BeierSeguros.Domain.Enums;
using BeierSeguros.Shared.Contracts;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.InsurerAssistances.Commands
{
    public class UpdateInsurerAssistanceCommand : ICommand, IRequest<Notifiable>
    {
        public Guid Id { get; set; }

        public string Phone { get; set; }

        public EAssistancePhoneType AssistancePhoneType { get; set; }

        public Guid InsurerId { get; set; }

    }
}
