using AutoMapper;
using ServiceStation.Application.Clients;
using ServiceStation.Application.Clients.Commands.CreateClient;
using ServiceStation.Application.Clients.Commands.DeleteClient;
using ServiceStation.Application.Clients.Commands.UpdateClient;
using ServiceStation.Domain.Entities.Clients;
using ServiceStation.Domain.Entities.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Mappings
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<Client, ClientDto>()
                .ForMember(e => e.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(e => e.Name, opt => opt.MapFrom(src => src.ContactDetails.Name))
                .ForMember(e => e.Surname, opt => opt.MapFrom(src => src.ContactDetails.Surname))
                .ForMember(e => e.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(e => e.Email, opt => opt.MapFrom(src => src.ContactDetails.Email))
                .ForMember(e => e.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(e => e.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(e => e.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode));
            CreateMap<CreateClientCommand, Client>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new ContactDetails()
                {
                     Id = src.Id,
                     Name = src.Name,
                     Surname = src.Surname,
                     PhoneNumber = src.PhoneNumber,
                     Email = src.Email,
                     Street = src.Street,
                     City = src.City,
                     PostalCode = src.PostalCode,
                }));
            CreateMap<UpdateClientCommand, Client>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new ContactDetails()
                {
                    Id = src.Id,
                    Name = src.Name,
                    Surname = src.Surname,
                    PhoneNumber = src.PhoneNumber,
                    Email = src.Email,
                    Street = src.Street,
                    City = src.City,
                    PostalCode = src.PostalCode,
                }));
            CreateMap<ClientDto, UpdateClientCommand>();
            CreateMap<ClientDto, DeleteClientCommand>();

        }
    }
}
