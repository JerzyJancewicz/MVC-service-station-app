using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStation.Domain.Interfaces;
using ServiceStation.Infrastructure.Presistance;
using ServiceStation.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            // Dodanie dbcontextu do pojemnika dependency Injection i dodanie do parametru connectionString ktory znajduje sie w pliku json
            services.AddDbContext<ServiceStationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("Default")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ServiceStationDbContext>();

            services.AddScoped<IServiceStationRepository, ServiceStationRepository>();
            services.AddScoped<IClientsRepository, ClientsRepository>();
        }
    }
}
