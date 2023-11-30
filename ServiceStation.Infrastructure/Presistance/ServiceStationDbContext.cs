using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Domain.Entities.Clients;
using ServiceStation.Domain.Entities.Details;
using ServiceStation.Domain.Entities.Services;
using ServiceStation.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Infrastructure.Presistance
{
    public class ServiceStationDbContext : IdentityDbContext
    {

        public ServiceStationDbContext(DbContextOptions<ServiceStationDbContext> options) : base(options) { }

        public DbSet<User> user { get; set; }
        public DbSet<ContactDetails> contactDetails { get; set; }
        public DbSet<Client> client { get; set; }
        public DbSet<Car> car { get; set; }
        public DbSet<Service> service { get; set; }
        public DbSet<Service_Type> service_Type { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();

                entity.HasOne(x => x.IdContactDetailsNavigation).WithMany(x => x.Users)
                    .HasForeignKey(x => x.IdContacDetails)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ContactDetails>(entity =>
            {
                entity.HasKey(x => x.Id);
                //entity.Property(x => x.Id).ValueGeneratedOnAdd();

                entity.Property(x => x.Name).HasMaxLength(255);
                entity.Property(x => x.Surname).HasMaxLength(255);
                entity.Property(x => x.Email).HasMaxLength(255);
                entity.Property(x => x.PhoneNumber).HasMaxLength(255);
                entity.Property(x => x.Street).HasMaxLength(255);
                entity.Property(x => x.City).HasMaxLength(255);
                entity.Property(x => x.PostalCode).HasMaxLength(255);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(x => x.Id);
                //entity.Property(x => x.Id).ValueGeneratedOnAdd();

                entity.HasOne(x => x.IdContactDetailsNavigation).WithMany(x => x.Clients)
                    .HasForeignKey(x => x.IdContactDetails)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(x => x.LicensePlate);
                //entity.Property(x => x.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LicensePlate).ValueGeneratedNever();
                entity.Property(e => e.LicensePlate).HasMaxLength(255);
                entity.Property(e => e.CarName).HasMaxLength(450);

                entity.HasOne(x => x.IdClientNavigation).WithMany(x => x.Cars)
                    .HasForeignKey(x => x.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById);

            });
            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(x => x.Id);
                //entity.Property(x => x.Id).ValueGeneratedOnAdd();

                entity.HasOne(x => x.IdCarNavigation).WithMany(x => x.Services)
                    .HasForeignKey(x => x.CarLicensePlate)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(x => x.IdServiceTypeNavigation).WithMany(x => x.Services)
                    .HasForeignKey(x => x.IdServiceType)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });
            modelBuilder.Entity<Service_Type>(entity =>
            {
                entity.HasKey(x => x.Id);
                //entity.Property(x => x.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ServiceTime).HasColumnType("time");
                entity.Property(e => e.ServiceName).HasMaxLength(255);

            });
        }
    }
}
