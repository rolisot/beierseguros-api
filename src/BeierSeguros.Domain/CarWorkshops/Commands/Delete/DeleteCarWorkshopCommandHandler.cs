using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Domain.CarWokshops.Repositories;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.CarWorkshops.Commands
{
    public class DeleteCarWorkshopCommandHandler : IRequestHandler<DeleteCarWorkshopCommand, Notifiable>
    {
        private readonly ICarWorkshopRepository _repository;

        public DeleteCarWorkshopCommandHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }

        public async Task<Notifiable> Handle(DeleteCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _repository.GetById(request.Id);

            if (carWorkshop == null)
                return new Notifiable(new NotifiableError("Oficina não cadastrada"));

            _repository.Remove(carWorkshop);
            await _repository.Save();

            return new Notifiable("Oficina excluída com sucesso");
        }
    }
}