using Microsoft.Extensions.DependencyInjection;
using ServiceStation.Application.Mappings;
using ServiceStation.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services) 
        {
            services.AddScoped<IServiceStationService, ServiceStationService>();

            services.AddAutoMapper(typeof(ServiceStationMappingProfile));
        }

    }
}
