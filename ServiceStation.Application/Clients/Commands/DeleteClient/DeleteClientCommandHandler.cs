using MediatR;
using ServiceStation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
    {

        private readonly IClientsRepository _repository;

        public DeleteClientCommandHandler(IClientsRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteClient(request.Id);
            return Unit.Value;
        }
    }
}
