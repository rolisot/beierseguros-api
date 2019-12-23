using System;
using System.Collections.Generic;
using BeierSeguros.Domain.InsurerAssistances.ViewModels;

namespace BeierSeguros.Domain.Insurers.ViewModels
{
    public class InsurerViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IReadOnlyCollection<InsurerAssistanceViewModel> Assistances { get; set; }

    }
}