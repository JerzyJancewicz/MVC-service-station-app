using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServiceStation.Application.ApplicationUser;
using ServiceStation.Application.Mappings;
using ServiceStation.Application.ServiceStation.Commands.CreateCar;
using ServiceStation.Application.ServiceStation.Commands.UpdateCar;
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
            services.AddScoped<IUserContext, UserContext>();
            services.AddMediatR(typeof(CreateCarCommand));

            services.AddScoped(provider => new MapperConfiguration(cfg => 
            {
                var scoped = provider.CreateScope();
                var userContext = scoped.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new ServiceStationMappingProfile(userContext));
            }).CreateMapper()
            );
            services.AddAutoMapper(typeof(ServiceStationMappingProfile));
            services.AddAutoMapper(typeof(ClientMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateCarCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

        }
    }
}
