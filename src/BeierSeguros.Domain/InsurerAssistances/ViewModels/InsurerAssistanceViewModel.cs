using System;
using BeierSeguros.Domain.Enums;

namespace BeierSeguros.Domain.InsurerAssistances.ViewModels
{
    public class InsurerAssistanceViewModel
    {
        public Guid Id { get; set; }

        public string Phone { get; set; }

        public EAssistancePhoneType AssistancePhoneType { get; set; }

        public Guid InsurerId { get; set; }
    }
}