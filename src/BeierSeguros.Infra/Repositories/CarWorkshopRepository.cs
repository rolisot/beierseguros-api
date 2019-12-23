using System;
using System.Linq;
using System.Threading.Tasks;
using BeierSeguros.Domain.CarWokshops.Repositories;
using BeierSeguros.Domain.CarWorkshops.Entities;
using BeierSeguros.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BeierSeguros.Infra.Repositories
{
    public class CarWorkshopRepository : Repository<CarWorkshop>, ICarWorkshopRepository
    {
        private new readonly AppDbContext _context;

        public CarWorkshopRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ValidateCityById(Guid cityId)
        {
            var city = await _context.Cities
                            .Where(x => x.Id == cityId)
                            .AsNoTracking().FirstOrDefaultAsync();

            return city != null;
        }

        public override async Task<CarWorkshop> GetById(Guid id)
        {
            return await GetByWhere(x => x.Id == id).Include(x => x.City).FirstOrDefaultAsync();
        }

        public async Task<CarWorkshop> GetByIdIncludeInsurers(Guid id)
        {
            return await _context.CarWorkshops
                            .Include(x => x.City)
                            .Include(x => x.CarWorkshopInsurers)
                                .ThenInclude(i => i.Insurer)
                            .FirstAsync(x => x.Id == id);
        }
    }
}