using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Domain.CarWokshops.Repositories;
using BeierSeguros.Domain.CarWorkshops.Entities;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.CarWorkshops.Commands
{
    public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopCommand, Notifiable>
    {
        private readonly ICarWorkshopRepository _repository;

        public CreateCarWorkshopCommandHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }

        public async Task<Notifiable> Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var existsCity = await _repository.ValidateCityById(request.CityId);

            if (!existsCity)
                return new Notifiable(new NotifiableError($"A Cidade {request.Name} não está cadastrada"));

            var carWorkshop = new CarWorkshop(request.Name, request.Phone, request.Address, request.CityId);

            await _repository.Add(carWorkshop);
            await _repository.Save();
            carWorkshop = await _repository.GetById(carWorkshop.Id);
            return new Notifiable("Oficina cadastrada com sucesso", carWorkshop);
        }
    }
}