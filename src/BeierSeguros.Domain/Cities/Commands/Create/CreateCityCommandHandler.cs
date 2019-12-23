using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Domain.Cities.Entities;
using BeierSeguros.Domain.Cities.Repositories;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.Cities.Commands
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Notifiable>
    {
        private readonly ICityRepository _repository;

        public CreateCityCommandHandler(ICityRepository repository)
        {
            _repository = repository;
        }

        public async Task<Notifiable> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.ExistsByName(request.Name, request.State);

            if (exists)
            {
                return new Notifiable(new NotifiableError($"A cidade '{request.Name}' já está cadastrada"));
            }

            var city = new City(request.Name, request.State);

            await _repository.Add(city);
            await _repository.Save();
            return new Notifiable("Cidade cadastrada com sucesso", city);
        }
    }
}