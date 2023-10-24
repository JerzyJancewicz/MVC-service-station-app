using Microsoft.EntityFrameworkCore;
using ServiceStation.Domain.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Infrastructure.Presistance
{
    public class ServiceStationDbContext : DbContext
    {
        public DbSet<ReplaceTyres> replaceTyres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Default");
        }
    }
}
