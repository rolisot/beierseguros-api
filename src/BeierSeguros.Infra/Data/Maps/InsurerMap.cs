using BeierSeguros.Domain.Insurers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeierSeguros.Infra.Data.Map
{
    public class InsurerMap : IEntityTypeConfiguration<Insurer>
    {
        public void Configure(EntityTypeBuilder<Insurer> builder)
        {
            builder.ToTable("Insurer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnType("varchar(120)");

            builder
                .HasMany(o => o.Assistances)
                .WithOne(x => x.Insurer)
                .HasForeignKey(x => x.InsurerId);
        }
    }
}