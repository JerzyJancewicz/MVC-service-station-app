using MediatR;
using ServiceStation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.ServiceStation.Commands.DeleteCar
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
    {
        private readonly IServiceStationRepository repository;

        public DeleteCarCommandHandler(IServiceStationRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteCar(request.LicensePlate);
            return Unit.Value;
        }
    }
}
