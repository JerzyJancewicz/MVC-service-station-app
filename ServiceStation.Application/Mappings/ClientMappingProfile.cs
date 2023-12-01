using AutoMapper;
using ServiceStation.Application.Clients;
using ServiceStation.Domain.Entities.Clients;
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
            //TODO: Create Mapping proflie that contains info from ContacDetails Entity or change the handler
            CreateMap<IEnumerable<Client>, IEnumerable<ClientDto>>(); // ! Wrong
        }
    }
}
