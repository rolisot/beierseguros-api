using System;
using BeierSeguros.Domain.CarWorkshops.Entities;
using BeierSeguros.Domain.Insurers.Entities;
using BeierSeguros.Shared.Entities;

namespace BeierSeguros.Domain.CarWorkshopsInsurers.Entities
{
    public class CarWorkshopInsurer : Entity
    {
        public CarWorkshopInsurer(Guid carWorkShopId, Guid insurerId)
        {
            CarWorkShopId = carWorkShopId;
            InsurerId = insurerId;
        }

        public Guid CarWorkShopId { get; private set; }

        public CarWorkshop CarWorkShop { get; private set; }

        public Guid InsurerId { get; private set; }

        public Insurer Insurer { get; private set; }
    }
}