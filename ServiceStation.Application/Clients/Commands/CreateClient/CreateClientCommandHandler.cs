using AutoMapper;
using MediatR;
using ServiceStation.Domain.Entities.Clients;
using ServiceStation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand>
    {
        private readonly IClientsRepository _repository;
        private readonly IMapper _mapper;

        public CreateClientCommandHandler(IClientsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Client>(request);
            await _repository.CreateClient(client);

            return Unit.Value;
        }
    }
}
