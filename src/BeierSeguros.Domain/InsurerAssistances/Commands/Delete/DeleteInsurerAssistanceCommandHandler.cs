using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Domain.Insurers.Repositories;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.InsurerAssistances.Commands
{
    public class DeleteInsurerAssistanceCommandHandler : IRequestHandler<DeleteInsurerAssistanceCommand, Notifiable>
    {
        private readonly IInsurerRepository _repository;

        public DeleteInsurerAssistanceCommandHandler(IInsurerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Notifiable> Handle(DeleteInsurerAssistanceCommand request, CancellationToken cancellationToken)
        {
            var insurer = await _repository.Find(request.InsurerId);

            if (insurer == null)
            {
                return new Notifiable(new NotifiableError($"A seguradora não está cadastrada"));
            }

            insurer.RemoveAssistance(request.Id);
            await _repository.Save();
            return new Notifiable("Assistência excluída com sucesso", insurer);
        }
    }
}