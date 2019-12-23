using System.Threading.Tasks;
using BeierSeguros.Domain.Cities.Entities;
using BeierSeguros.Shared.Repositories;

namespace BeierSeguros.Domain.Cities.Repositories
{
    public interface ICityRepository : IRepository<City>
    {
        Task<bool> ExistsByName(string name, string state);
    }
}