using BeierSeguros.Domain.Cities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeierSeguros.Infra.Data.Map
{
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnType("varchar(120)");

            builder.Property(x => x.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnType("varchar(2)");
        }
    }
}