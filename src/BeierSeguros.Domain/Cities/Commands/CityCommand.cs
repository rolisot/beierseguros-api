using System;
using BeierSeguros.Shared.Contracts;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.Cities.Commands
{
    public abstract class CityCommand : ICommand, IRequest<Notifiable>
    {
        public Guid Id { get; set; }

        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value?.Trim();
        }

        private string _state;

        public string State
        {
            get => _state;
            set => _state = value?.Trim().ToUpper();
        }
    }
}
