using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Domain.Insurers.Repositories;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.Insurers.Commands
{
    public class DeleteInsurerCommandHandler : IRequestHandler<DeleteInsurerCommand, Notifiable>
    {
        private readonly IInsurerRepository _repository;

        public DeleteInsurerCommandHandler(IInsurerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Notifiable> Handle(DeleteInsurerCommand request, CancellationToken cancellationToken)
        {
            var insurer = await _repository.GetById(request.Id);

            if (insurer == null)
                return new Notifiable(new NotifiableError("A seguradora informada não está cadastrada"));

            _repository.Remove(insurer);
            await _repository.Save();
            return new Notifiable("Seguradora excluída com sucesso");
        }
    }
}