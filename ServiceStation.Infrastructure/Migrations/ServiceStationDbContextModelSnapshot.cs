﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceStation.Infrastructure.Presistance;

#nullable disable

namespace ServiceStation.Infrastructure.Migrations
{
    [DbContext(typeof(ServiceStationDbContext))]
    partial class ServiceStationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ServiceStation.Domain.Entities.Clients.Car", b =>
                {
                    b.Property<string>("LicensePlate")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("LicensePlate");

                    b.HasIndex("IdClient");

                    b.ToTable("car");
                });

            modelBuilder.Entity("ServiceStation.Domain.Entities.Clients.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdContactDetails")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdContactDetails");

                    b.ToTable("client");
                });

            modelBuilder.Entity("ServiceStation.Domain.Entities.Details.ContactDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Street")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("contactDetails");
                });

            modelBuilder.Entity("ServiceStation.Domain.Entities.Services.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CarLicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdServiceType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarLicensePlate");

                    b.HasIndex("IdServiceType");

                    b.ToTable("service");
                });

            modelBuilder.Entity("ServiceStation.Domain.Entities.Services.Service_Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EncodedServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<TimeSpan>("ServiceTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("service_Type");
                });

            modelBuilder.Entity("ServiceStation.Domain.Entities.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdContacDetails")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdContacDetails");

                    b.ToTable("user");
                });

            modelBuilder.Entity("ServiceStation.Domain.Entities.Clients.Car", b =>
                {
                    b.HasOne("ServiceStation.Domain.Entities.Clients.Client", "IdClientNavigation")
                        .WithMany("Cars")
                        .HasForeignKey("IdClient")
                        .IsRequired();

                    b.Navigation("IdClientNavigation");
                });

            modelBuilder.Entity("ServiceStation.Domain.Entities.Clients.Client", b =>
                {
                    b.HasOne("ServiceStation.Domain.Entities.Details.ContactDetails", "IdContactDetailsNavigation")
                        .WithMany("Clients")
                        .HasForeignKey("IdContactDetails")
                        .IsRequired();

                    b.Navigation("IdContactDetailsNavigation");
                });

            modelBuilder.Entity("ServiceStation.Domain.Entities.Services.Service", b =>
                {
                    b.HasOne("ServiceStation.Domain.Entities.Clients.Car", "IdCarNavigation")
                        .WithMany("Services")
                        .HasForeignKey("CarLicensePlate")
                        .IsRequired();

                    b.HasOne("ServiceStation.Domain.Entities.Services.Service_Type", "IdServiceTypeNavigation")
                        .WithMany("Services")
                        .HasForeignKey("IdServiceType")
                        .IsRequired();

                    b.Navigation("IdCarNavigation");

                    b.Navigation("IdServiceTypeNavigation");
                });

            modelBuilder.Entity("ServiceStation.Domain.Entities.Users.User", b =>
                {
                    b.HasOne("ServiceStation.Domain.Entities.Details.ContactDetails", "IdContactDetailsNavigation")
                        .WithMany("Users")
                        .HasForeignKey("IdContacDetails")
                        .IsRequired();

                    b.Navigation("IdContactDetailsNavigation");
                });

            modelBuilder.Entity("ServiceStation.Domain.Entities.Clients.Car", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("ServiceStation.Domain.Entities.Clients.Client", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("ServiceStation.Domain.Entities.Details.ContactDetails", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ServiceStation.Domain.Entities.Services.Service_Type", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
