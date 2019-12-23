using System.Threading.Tasks;
using BeierSeguros.Domain.Cities.Entities;
using BeierSeguros.Domain.Cities.Repositories;
using BeierSeguros.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BeierSeguros.Infra.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {

        public CityRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<bool> ExistsByName(string name, string state)
        {
            var entity = await this.GetByWhere(x => x.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase) &&
                                                    x.State.Equals(state, System.StringComparison.InvariantCultureIgnoreCase))
                                    .FirstOrDefaultAsync();

            return entity != null;
        }
    }
}