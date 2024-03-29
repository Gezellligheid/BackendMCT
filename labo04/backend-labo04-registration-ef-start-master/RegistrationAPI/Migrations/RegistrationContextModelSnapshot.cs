﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistrationAPI.data;

namespace RegistrationAPI.Migrations
{
    [DbContext(typeof(RegistrationContext))]
    partial class RegistrationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RegistrationAPI.Models.VaccinType", b =>
                {
                    b.Property<Guid>("VaccinTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VaccinTypeId");

                    b.ToTable("VaccinTypes");

                    b.HasData(
                        new
                        {
                            VaccinTypeId = new Guid("9aa0a7cb-0be0-4a4e-8af4-b9a3f4c664a2"),
                            Name = "Pfizer"
                        });
                });

            modelBuilder.Entity("RegistrationAPI.Models.VaccinationLocation", b =>
                {
                    b.Property<Guid>("VaccinationLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VaccinationLocationId");

                    b.ToTable("VaccinationLocations");

                    b.HasData(
                        new
                        {
                            VaccinationLocationId = new Guid("fe53e192-7546-42d6-b9bd-0e382b4c9278"),
                            Name = "The Penta"
                        });
                });

            modelBuilder.Entity("RegistrationAPI.Models.VaccinationRegistration", b =>
                {
                    b.Property<Guid>("VaccinationRegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VaccinTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VaccinationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VaccinationLocationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VaccinationRegistrationId");

                    b.ToTable("VaccinationRegistrations");
                });
#pragma warning restore 612, 618
        }
    }
}
