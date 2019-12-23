using System;
using BeierSeguros.Shared.Contracts;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.CarWorkshopsInsurers.Command
{
    public class CreateCarWorkshopInsurerCommand : ICommand, IRequest<Notifiable>
    {
        public Guid CarWorkShopId { get; set; }

        public Guid InsurerId { get; set; }
    }
}