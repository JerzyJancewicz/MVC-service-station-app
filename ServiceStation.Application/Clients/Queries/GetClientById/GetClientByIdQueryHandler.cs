using AutoMapper;
using MediatR;
using ServiceStation.Application.ServiceStation;
using ServiceStation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Clients.Queries.GetClientById
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientDto>
    {
        private readonly IClientsRepository _repository;
        private readonly IMapper _mapper;

        public GetClientByIdQueryHandler(IClientsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _repository.GetByName(request.Id);
            var clientDto = _mapper.Map<ClientDto>(client);

            return clientDto;
        }
    }
}
