using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Domain.CarWokshops.Repositories;
using BeierSeguros.Domain.CarWorkshopsInsurers.Entities;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.CarWorkshopsInsurers.Command
{
    public class CreateCarWorkshopInsurerCommandHandler : IRequestHandler<CreateCarWorkshopInsurerCommand, Notifiable>
    {
        private readonly ICarWorkshopRepository _repository;

        public CreateCarWorkshopInsurerCommandHandler(ICarWorkshopRepository respository)
        {
            _repository = respository;
        }

        public async Task<Notifiable> Handle(CreateCarWorkshopInsurerCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _repository.GetByIdIncludeInsurers(request.CarWorkShopId);

            if (carWorkshop == null)
            {
                return new Notifiable(new NotifiableError($"A seguradora não está cadastrada"));
            }


            var insurer = new CarWorkshopInsurer(request.CarWorkShopId, request.InsurerId);
            carWorkshop.AddCarWorkshopInsurer(insurer);
            await _repository.Save();
            return new Notifiable("Seguradora adicionada com sucesso", carWorkshop);
        }
    }
}