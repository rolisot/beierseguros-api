using System;
using System.Collections.Generic;
using BeierSeguros.Domain.CarWorkshops.Entities;
using BeierSeguros.Shared.Entities;

namespace BeierSeguros.Domain.Cities.Entities
{
    public class City : Entity
    {
        public City(string name, string state)
        {
            Name = name;
            State = state;
        }

        public City(Guid id, string name, string state)
        {
            Id = id;
            Name = name;
            State = state;
        }

        public string Name { get; private set; }

        public string State { get; private set; }

        public IEnumerable<CarWorkshop> CarWorkshops { get; private set; }

    }
}