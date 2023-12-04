using MediatR;
using ServiceStation.Application.ServiceStation.Queries.GetAllCar;
using ServiceStation.Application.ServiceStation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStation.Domain.Interfaces;
using AutoMapper;
using ServiceStation.Domain.Entities.Clients;

namespace ServiceStation.Application.Clients.Queries.GetAllClients
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientDto>>
    {
        private readonly IClientsRepository _repository;
        private readonly IMapper _mapper;

        public GetAllClientsQueryHandler(IClientsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClientDto>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _repository.GetAll();

           /* var clientsDtos = new List<ClientDto>();
            foreach (var item in clients)
            {
                var clientDto = _mapper.Map<ClientDto>(item);
                clientsDtos.Add(clientDto);
            }*/

            var dtos = _mapper.Map<IEnumerable<ClientDto>>(clients);

            return dtos;   
        }
    }
}
