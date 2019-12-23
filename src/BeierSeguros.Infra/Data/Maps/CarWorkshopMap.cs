using BeierSeguros.Domain.CarWorkshops.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeierSeguros.Infra.Data.Map
{
    public class CarWorkshopMap : IEntityTypeConfiguration<CarWorkshop>
    {
        public void Configure(EntityTypeBuilder<CarWorkshop> builder)
        {
            builder.ToTable("CarWorkshop");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnType("varchar(120)");

            builder.Property(x => x.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnType("varchar(15)");

            builder.Property(x => x.Address)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnType("varchar(120)");

            builder.Property(x => x.CityId)
                    .IsRequired();

            // mapping FK        
            builder.HasOne(x => x.City).WithMany(x => x.CarWorkshops).HasForeignKey(x => x.CityId);
        }
    }
}