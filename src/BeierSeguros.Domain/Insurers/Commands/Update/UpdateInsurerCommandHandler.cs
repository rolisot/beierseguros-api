using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Domain.Insurers.Entities;
using BeierSeguros.Domain.Insurers.Repositories;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.Insurers.Commands
{
    public class UpdateInsurerCommandHandler : IRequestHandler<UpdateInsurerCommand, Notifiable>
    {
        private readonly IInsurerRepository _repository;

        public UpdateInsurerCommandHandler(IInsurerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Notifiable> Handle(UpdateInsurerCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.Exists(x => x.Id == request.Id);

            if (!exists)
                return new Notifiable(new NotifiableError("A seguradora informada não está cadastrada"));

            var updated = new Insurer(request.Id, request.Name);

            _repository.Update(updated);
            await _repository.Save();
            return new Notifiable("Seguradora cadastrada com sucesso", updated);
        }
    }
}