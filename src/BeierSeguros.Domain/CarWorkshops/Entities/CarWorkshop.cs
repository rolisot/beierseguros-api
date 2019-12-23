using System;
using System.Collections.Generic;
using BeierSeguros.Domain.CarWorkshopsInsurers.Entities;
using BeierSeguros.Domain.Cities.Entities;
using BeierSeguros.Shared.Entities;

namespace BeierSeguros.Domain.CarWorkshops.Entities
{
    public class CarWorkshop : Entity
    {
        public CarWorkshop(string name, string phone, string address, Guid cityId)
        {
            Name = name;
            Phone = phone;
            Address = address;
            CityId = cityId;
            _carWorkshopInsurers = new List<CarWorkshopInsurer>();
        }

        public CarWorkshop(Guid id, string name, string phone, string address, Guid cityId)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Address = address;
            CityId = cityId;
            _carWorkshopInsurers = new List<CarWorkshopInsurer>();
        }

        public string Name { get; private set; }

        public string Phone { get; private set; }

        public string Address { get; private set; }

        public Guid CityId { get; private set; }

        public City City { get; private set; }

        private readonly List<CarWorkshopInsurer> _carWorkshopInsurers;

        public IReadOnlyCollection<CarWorkshopInsurer> CarWorkshopInsurers => _carWorkshopInsurers;

        public void AddCarWorkshopInsurer(CarWorkshopInsurer insurer)
        {
            _carWorkshopInsurers.Add(insurer);
        }

        public void RemoveCarWorkshopInsurer(Guid carWorkshopInsurerId)
        {
            var itemToRemove = _carWorkshopInsurers.Find(x => x.Id == carWorkshopInsurerId);

            if (itemToRemove != null)
            {
                _carWorkshopInsurers.Remove(itemToRemove);
            }
        }
    }
}