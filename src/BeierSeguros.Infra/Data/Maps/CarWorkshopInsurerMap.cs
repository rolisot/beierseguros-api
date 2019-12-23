using BeierSeguros.Domain.CarWorkshopsInsurers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeierSeguros.Infra.Data.Map
{
    public class CarWorkshopInsurerMap : IEntityTypeConfiguration<CarWorkshopInsurer>
    {
        public void Configure(EntityTypeBuilder<CarWorkshopInsurer> builder)
        {
            builder.ToTable("CarWorkshopInsurer");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever();

            // mapping FKs       
            builder.HasOne(x => x.CarWorkShop).WithMany(x => x.CarWorkshopInsurers).HasForeignKey(x => x.CarWorkShopId);
            builder.HasOne(x => x.Insurer).WithMany(x => x.CarWorkshopInsurers).HasForeignKey(x => x.InsurerId);
        }
    }
}