using BeierSeguros.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeierSeguros.Infra.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnType("varchar(120)");

            builder.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnType("varchar(60)");

            builder.Property(x => x.Password)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnType("varchar(120)");
        }
    }
}