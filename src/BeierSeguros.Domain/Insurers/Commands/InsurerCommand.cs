using System;
using BeierSeguros.Shared.Contracts;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.Insurers.Commands
{
    public class InsurerCommand : ICommand, IRequest<Notifiable>
    {
        public Guid Id { get; set; }

        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value?.Trim();
        }
    }
}
