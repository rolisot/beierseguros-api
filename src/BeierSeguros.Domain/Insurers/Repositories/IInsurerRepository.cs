using System;
using System.Threading.Tasks;
using BeierSeguros.Domain.Insurers.Entities;
using BeierSeguros.Shared.Repositories;

namespace BeierSeguros.Domain.Insurers.Repositories
{
    public interface IInsurerRepository : IRepository<Insurer>
    {
        Task<bool> ExistsByName(string name);

        Task<Insurer> GetByIdAndAssistanceId(Guid id, Guid assistanceId);
    }
}