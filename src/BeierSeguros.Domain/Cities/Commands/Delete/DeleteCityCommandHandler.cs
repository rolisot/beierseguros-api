using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Domain.Cities.Repositories;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.Cities.Commands
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Notifiable>
    {
        private readonly ICityRepository _repository;

        public DeleteCityCommandHandler(ICityRepository repository)
        {
            _repository = repository;
        }

        public async Task<Notifiable> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _repository.GetById(request.Id);

            if (city == null)
            {
                return new Notifiable(new NotifiableError($"A cidade '{request.Name}' não está cadastrada"));
            }

            _repository.Remove(city);
            await _repository.Save();
            return new Notifiable("Cidade excluída com sucesso");
        }
    }
}