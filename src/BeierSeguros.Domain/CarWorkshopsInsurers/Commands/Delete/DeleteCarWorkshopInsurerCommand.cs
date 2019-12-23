using System;
using BeierSeguros.Shared.Contracts;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.CarWorkshopsInsurers.Command
{
    public class DeleteCarWorkshopInsurerCommand : ICommand, IRequest<Notifiable>
    {
        public Guid CarWorkshopId { get; set; }

        public Guid CarWorkshopInsurerId { get; set; }
    }
}