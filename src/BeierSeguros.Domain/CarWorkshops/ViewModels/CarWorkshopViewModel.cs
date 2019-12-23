using System.Collections.Generic;
using BeierSeguros.Domain.CarWorkshopsInsurers.ViewModels;

namespace BeierSeguros.Domain.CarWorkshops.ViewModels
{
    public class CarWorkshopViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string CityId { get; set; }

        public string CityName { get; set; }

        public IReadOnlyCollection<CarWorkshopInsurerViewModel> CarWorkshopInsurers { get; set; }

    }
}