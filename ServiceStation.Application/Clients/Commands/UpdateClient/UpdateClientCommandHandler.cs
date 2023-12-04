using AutoMapper;
using MediatR;
using ServiceStation.Domain.Entities.Clients;
using ServiceStation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
    {
        private readonly IClientsRepository _repository;
        private readonly IMapper _mapper;

        public UpdateClientCommandHandler(IClientsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Client>(request);

            await _repository.Update(client);

            return Unit.Value;
        }
    }
}
