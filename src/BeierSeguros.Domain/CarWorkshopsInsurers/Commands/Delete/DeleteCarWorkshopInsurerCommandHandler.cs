using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Domain.CarWokshops.Repositories;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.CarWorkshopsInsurers.Command
{
    public class DeleteCarWorkshopInsurerCommandHandler : IRequestHandler<DeleteCarWorkshopInsurerCommand, Notifiable>
    {
        private readonly ICarWorkshopRepository _repository;

        public DeleteCarWorkshopInsurerCommandHandler(ICarWorkshopRepository respository)
        {
            _repository = respository;
        }

        public async Task<Notifiable> Handle(DeleteCarWorkshopInsurerCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _repository.GetByIdIncludeInsurers(request.CarWorkshopId);

            if (carWorkshop == null)
            {
                return new Notifiable(new NotifiableError($"A oficina informada não está cadastrada"));
            }

            carWorkshop.RemoveCarWorkshopInsurer(request.CarWorkshopInsurerId);
            await _repository.Save();
            return new Notifiable("Assistência excluída com sucesso", carWorkshop);
        }
    }
}