using System;
using System.Threading.Tasks;
using BeierSeguros.Domain.CarWorkshops.Entities;
using BeierSeguros.Shared.Repositories;

namespace BeierSeguros.Domain.CarWokshops.Repositories
{
    public interface ICarWorkshopRepository : IRepository<CarWorkshop>
    {
        Task<bool> ValidateCityById(Guid cityId);

        Task<CarWorkshop> GetByIdIncludeInsurers(Guid id);
    }
}