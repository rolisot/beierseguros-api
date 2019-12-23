using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Domain.InsurerAssistances.Entities;
using BeierSeguros.Domain.Insurers.Repositories;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.InsurerAssistances.Commands
{
    public class CreateInsurerAssistanceCommandHandler : IRequestHandler<CreateInsurerAssistanceCommand, Notifiable>
    {
        private readonly IInsurerRepository _repository;

        public CreateInsurerAssistanceCommandHandler(IInsurerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Notifiable> Handle(CreateInsurerAssistanceCommand request, CancellationToken cancellationToken)
        {
            var insurer = await _repository.Find(request.InsurerId);

            if (insurer == null)
            {
                return new Notifiable(new NotifiableError($"A seguradora não está cadastrada"));
            }


            var assistance = new InsurerAssistance(request.Phone, request.AssistancePhoneType, request.InsurerId);
            insurer.AddAssistance(assistance);
            await _repository.Save();
            return new Notifiable("Assistência cadastrada com sucesso", insurer);
        }
    }
}