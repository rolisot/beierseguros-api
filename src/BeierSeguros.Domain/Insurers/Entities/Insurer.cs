using System;
using System.Collections.Generic;
using BeierSeguros.Domain.CarWorkshopsInsurers.Entities;
using BeierSeguros.Domain.InsurerAssistances.Entities;
using BeierSeguros.Shared.Entities;

namespace BeierSeguros.Domain.Insurers.Entities
{
    public class Insurer : Entity
    {
        public Insurer(string name)
        {
            Name = name;
            _assistances = new List<InsurerAssistance>();
        }

        public Insurer(Guid id, string name)
        {
            Id = id;
            Name = name;
            _assistances = new List<InsurerAssistance>();
        }

        public void AddAssistance(InsurerAssistance assistance)
        {
            _assistances.Add(assistance);
        }

        public void UpdateAssistance(InsurerAssistance assistance)
        {
            var assistanceToRemove = _assistances.Find(x => x.Id == assistance.Id);

            if (assistanceToRemove != null)
            {
                _assistances.Remove(assistanceToRemove);
                _assistances.Add(assistance);
            }
        }

        public void RemoveAssistance(Guid assistanceId)
        {
            var assistanceToRemove = _assistances.Find(x => x.Id == assistanceId);

            if (assistanceToRemove != null)
            {
                _assistances.Remove(assistanceToRemove);
            }
        }

        private readonly List<InsurerAssistance> _assistances;

        public IReadOnlyCollection<InsurerAssistance> Assistances => _assistances;

        public string Name { get; private set; }

        public IEnumerable<CarWorkshopInsurer> CarWorkshopInsurers { get; private set; }

    }
}