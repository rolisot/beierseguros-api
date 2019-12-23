using System;
using System.Linq;
using System.Threading.Tasks;
using BeierSeguros.Domain.Insurers.Entities;
using BeierSeguros.Domain.Insurers.Repositories;
using BeierSeguros.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BeierSeguros.Infra.Repositories
{
    public class InsurerRepository : Repository<Insurer>, IInsurerRepository
    {

        public InsurerRepository(AppDbContext context) : base(context)
        {

        }

        public override async Task<Insurer> GetById(Guid id)
        {
            return await GetByWhere(x => x.Id == id)
                        .Include(x => x.Assistances)
                        .FirstOrDefaultAsync();
        }

        public async Task<Insurer> GetByIdAndAssistanceId(Guid id, Guid assistanceId)
        {
            return await GetByWhere(x => x.Id == id && x.Assistances.Any(a => a.Id == assistanceId))
                        .Include(x => x.Assistances)
                        .FirstOrDefaultAsync();
        }

        public async Task<bool> ExistsByName(string name)
        {
            var entity = await this.GetByWhere(x => x.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase))
                                    .FirstOrDefaultAsync();

            return entity != null;
        }

        public override async Task<Insurer> Find(Guid id)
        {
            var insurer = await base.Find(id);
            await _context.Entry(insurer).Collection(x => x.Assistances).LoadAsync();
            return insurer;
        }
    }
}