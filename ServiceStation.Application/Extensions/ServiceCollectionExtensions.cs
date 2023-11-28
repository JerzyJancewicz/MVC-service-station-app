using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServiceStation.Application.Mappings;
using ServiceStation.Application.ServiceStation.Commands.CreateCar;
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
            services.AddMediatR(typeof(CreateCarCommand));

            services.AddAutoMapper(typeof(ServiceStationMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateCarCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }

    }
}
