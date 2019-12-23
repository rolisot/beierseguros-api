using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Domain.Insurers.Entities;
using BeierSeguros.Domain.Insurers.Repositories;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.Insurers.Commands
{
    public class CreateInsurerCommandHandler : IRequestHandler<CreateInsurerCommand, Notifiable>
    {
        private readonly IInsurerRepository _repository;

        public CreateInsurerCommandHandler(IInsurerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Notifiable> Handle(CreateInsurerCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.ExistsByName(request.Name);

            if (exists)
            {
                return new Notifiable(new NotifiableError($"A seguradora '{request.Name}' já está cadastrada"));
            }

            var insurer = new Insurer(request.Name);
            await _repository.Add(insurer);
            await _repository.Save();
            return new Notifiable("Seguradora cadastrada com sucesso", insurer);
        }
    }
}