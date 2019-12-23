using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Domain.InsurerAssistances.Entities;
using BeierSeguros.Domain.Insurers.Repositories;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.InsurerAssistances.Commands
{
    public class UpdateInsurerAssistanceCommandHandler : IRequestHandler<UpdateInsurerAssistanceCommand, Notifiable>
    {
        private readonly IInsurerRepository _repository;

        public UpdateInsurerAssistanceCommandHandler(IInsurerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Notifiable> Handle(UpdateInsurerAssistanceCommand request, CancellationToken cancellationToken)
        {
            var insurer = await _repository.Find(request.InsurerId);

            if (insurer == null)
            {
                return new Notifiable(new NotifiableError($"A seguradora não está cadastrada"));
            }

            var assistance = new InsurerAssistance(request.Id, request.Phone, request.AssistancePhoneType, request.InsurerId);
            insurer.UpdateAssistance(assistance);
            await _repository.Save();
            return new Notifiable("Assistência atualizada com sucesso", insurer);
        }
    }
}