﻿// <auto-generated />
using System;
using BeierSeguros.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeierSeguros.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BeierSeguros.Domain.CarWorkshops.Entities.CarWorkshop", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<Guid>("CityId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("CarWorkshop");
                });

            modelBuilder.Entity("BeierSeguros.Domain.CarWorkshopsInsurers.Entities.CarWorkshopInsurer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CarWorkShopId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("InsurerId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CarWorkShopId");

                    b.HasIndex("InsurerId");

                    b.ToTable("CarWorkshopInsurer");
                });

            modelBuilder.Entity("BeierSeguros.Domain.Cities.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("BeierSeguros.Domain.InsurerAssistances.Entities.InsurerAssistance", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("AssistancePhoneType")
                        .IsRequired()
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1);

                    b.Property<Guid>("InsurerId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("InsurerId");

                    b.ToTable("InsurerAssistance");
                });

            modelBuilder.Entity("BeierSeguros.Domain.Insurers.Entities.Insurer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.ToTable("Insurer");
                });

            modelBuilder.Entity("BeierSeguros.Domain.Users.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BeierSeguros.Domain.CarWorkshops.Entities.CarWorkshop", b =>
                {
                    b.HasOne("BeierSeguros.Domain.Cities.Entities.City", "City")
                        .WithMany("CarWorkshops")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeierSeguros.Domain.CarWorkshopsInsurers.Entities.CarWorkshopInsurer", b =>
                {
                    b.HasOne("BeierSeguros.Domain.CarWorkshops.Entities.CarWorkshop", "CarWorkShop")
                        .WithMany("CarWorkshopInsurers")
                        .HasForeignKey("CarWorkShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeierSeguros.Domain.Insurers.Entities.Insurer", "Insurer")
                        .WithMany("CarWorkshopInsurers")
                        .HasForeignKey("InsurerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeierSeguros.Domain.InsurerAssistances.Entities.InsurerAssistance", b =>
                {
                    b.HasOne("BeierSeguros.Domain.Insurers.Entities.Insurer", "Insurer")
                        .WithMany("Assistances")
                        .HasForeignKey("InsurerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}