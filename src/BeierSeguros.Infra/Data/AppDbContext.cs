using Microsoft.EntityFrameworkCore;
using BeierSeguros.Infra.Data.Map;
using BeierSeguros.Domain.Data;
using BeierSeguros.Domain.CarWorkshops.Entities;
using BeierSeguros.Domain.Insurers.Entities;
using BeierSeguros.Domain.Cities.Entities;
using BeierSeguros.Domain.InsurerAssistances.Entities;
using BeierSeguros.Domain.CarWorkshopsInsurers.Entities;
using BeierSeguros.Domain.Users.Entities;

namespace BeierSeguros.Infra.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext() : base()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CarWorkshop> CarWorkshops { get; set; }

        public DbSet<Insurer> Insurers { get; set; }

        public DbSet<InsurerAssistance> InsurerAssistances { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<CarWorkshopInsurer> CarWorkshopInsurers { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=127.0.0.1,3306;Database=beierdb;User ID=root; Password=root");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CityMap());
            builder.ApplyConfiguration(new CarWorkshopMap());
            builder.ApplyConfiguration(new InsurerMap());
            builder.ApplyConfiguration(new InsurerAssistanceMap());
            builder.ApplyConfiguration(new CarWorkshopInsurerMap());
            builder.ApplyConfiguration(new UserMap());
        }
    }
}