using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Domain.Cities.Entities;
using BeierSeguros.Domain.Cities.Repositories;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.Cities.Commands
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, Notifiable>
    {
        private readonly ICityRepository _repository;

        public UpdateCityCommandHandler(ICityRepository repository)
        {
            _repository = repository;
        }

        public async Task<Notifiable> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.Exists(x => x.Id == request.Id);

            if (!exists)
            {
                return new Notifiable(new NotifiableError($"A cidade '{request.Name}' não está cadastrada"));
            }

            var updateCity = new City(request.Id, request.Name, request.State);

            _repository.Update(updateCity);
            await _repository.Save();
            return new Notifiable("Cidade cadastrada com sucesso", updateCity);
        }
    }
}