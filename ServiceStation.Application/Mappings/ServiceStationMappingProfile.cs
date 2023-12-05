using AutoMapper;
using ServiceStation.Application.ApplicationUser;
using ServiceStation.Application.ServiceStation;
using ServiceStation.Application.ServiceStation.Commands.DeleteCar;
using ServiceStation.Application.ServiceStation.Commands.UpdateCar;
using ServiceStation.Domain.Entities.Clients;
using ServiceStation.Domain.Entities.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Mappings
{
    public class ServiceStationMappingProfile : Profile
    {
        // dla obiektow, ktorych autoMapper nie wykryje
        /*.ForMember(e => e.LicensePlate, opt => opt.MapFrom(src => new ContactDetails()
        {
            PhoneNumber = src.Name
        })); ;*/
        public ServiceStationMappingProfile(IUserContext userContext)
        {
            //var user = userContext.GetCurrentUser();

            CreateMap<CarDto, Car>();
            CreateMap<Car, CarDto>();
                //.ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user !=null &&  src.CreatedById == user.Id));
            CreateMap<CarDto, UpdateCarCommand>();
            CreateMap<UpdateCarCommand, CarDto>();
            CreateMap<CarDto, DeleteCarCommand>();
        }
    }
}
