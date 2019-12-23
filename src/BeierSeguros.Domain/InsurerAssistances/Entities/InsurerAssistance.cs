using System;
using BeierSeguros.Domain.Enums;
using BeierSeguros.Domain.Insurers.Entities;
using BeierSeguros.Shared.Entities;

namespace BeierSeguros.Domain.InsurerAssistances.Entities
{
    public class InsurerAssistance : Entity
    {
        public InsurerAssistance(string phone, EAssistancePhoneType assistancePhoneType, Guid insurerId)
        {
            Phone = phone;
            AssistancePhoneType = assistancePhoneType;
            InsurerId = insurerId;
        }

        public InsurerAssistance(Guid id, string phone, EAssistancePhoneType assistancePhoneType, Guid insurerId)
        {
            Id = id;
            Phone = phone;
            AssistancePhoneType = assistancePhoneType;
            InsurerId = insurerId;
        }

        public string Phone { get; private set; }

        public EAssistancePhoneType AssistancePhoneType { get; private set; }

        public Guid InsurerId { get; private set; }

        public Insurer Insurer { get; private set; }
    }
}