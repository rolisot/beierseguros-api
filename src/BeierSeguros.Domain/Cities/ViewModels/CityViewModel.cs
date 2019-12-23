using System;

namespace BeierSeguros.Domain.Cities.ViewModels
{
    public class CityViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }
    }
}