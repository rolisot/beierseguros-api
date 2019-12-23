using BeierSeguros.Domain.CarWokshops.Repositories;
using BeierSeguros.Domain.Cities.Repositories;
using BeierSeguros.Domain.Insurers.Repositories;
using BeierSeguros.Domain.Users.Repositories;
using BeierSeguros.Infra.Repositories;
using BeierSeguros.Shared.Notifications;
using BeierSeguros.Shared.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BeierSeguros.Infra.Dependencies
{
    public static class DependencyInjectionRegistry
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<INotifiable, Notifiable>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICarWorkshopRepository, CarWorkshopRepository>();
            services.AddScoped<IInsurerRepository, InsurerRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}