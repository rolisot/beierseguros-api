using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Domain.CarWokshops.Repositories;
using BeierSeguros.Domain.CarWorkshops.Entities;
using BeierSeguros.Shared.Contracts;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.CarWorkshops.Commands
{
    public class UpdateCarWorkshopCommandHandler : IRequestHandler<UpdateCarWorkshopCommand, Notifiable>
    {
        private readonly ICarWorkshopRepository _repository;

        public UpdateCarWorkshopCommandHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }

        public async Task<Notifiable> Handle(UpdateCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var notifiable = new Notifiable();
            var existsCity = await _repository.ValidateCityById(request.CityId);

            if (!existsCity)
                notifiable.AddError($"A cidade não está cadastrada");

            var exists = await _repository.Exists(x => x.Id == request.Id);

            if (!exists)
                notifiable.AddError($"A oficina {request.Name} não está cadastrada");

            if (!notifiable.HasErrors)
            {
                var updated = new CarWorkshop(request.Id, request.Name, request.Phone, request.Address, request.CityId);

                _repository.Update(updated);
                await _repository.Save();
                updated = await _repository.GetById(updated.Id);
                notifiable.SetData(updated);
                notifiable.SetMessage("");
            }

            return notifiable;
        }
    }
}