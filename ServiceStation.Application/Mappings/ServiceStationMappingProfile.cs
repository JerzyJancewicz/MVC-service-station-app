using AutoMapper;
using ServiceStation.Application.ServiceStation;
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
        public ServiceStationMappingProfile()
        {
            CreateMap<CarDto, Car>();
        }
    }
}
