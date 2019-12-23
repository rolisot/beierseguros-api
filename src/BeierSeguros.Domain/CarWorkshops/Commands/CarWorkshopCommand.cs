using System;
using BeierSeguros.Shared.Contracts;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.CarWorkshops.Commands
{
    public class CarWorkshopCommand : ICommand, IRequest<Notifiable>
    {
        public Guid Id { get; set; }

        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value?.Trim();
        }

        private string _phone;

        public string Phone
        {
            get => _phone;
            set => _phone = value?.Trim();
        }

        private string _address;

        public string Address
        {
            get => _address;
            set => _address = value?.Trim();
        }

        public Guid CityId { get; set; }
    }
}
