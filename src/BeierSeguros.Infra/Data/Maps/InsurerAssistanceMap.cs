using BeierSeguros.Domain.Enums;
using BeierSeguros.Domain.InsurerAssistances.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeierSeguros.Infra.Data.Map
{
    public class InsurerAssistanceMap : IEntityTypeConfiguration<InsurerAssistance>
    {
        public void Configure(EntityTypeBuilder<InsurerAssistance> builder)
        {
            builder.ToTable("InsurerAssistance");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnType("varchar(15)");

            builder.Property(x => x.AssistancePhoneType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnType("varchar(1)")
                    .HasConversion(x => (int)x, x => (EAssistancePhoneType)x);

            builder.Property(x => x.InsurerId)
                    .IsRequired();

            // mapping FK        
            builder.HasOne(x => x.Insurer).WithMany(x => x.Assistances).HasForeignKey(x => x.InsurerId);
        }
    }
}