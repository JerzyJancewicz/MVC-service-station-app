using AutoMapper;
using MediatR;
using ServiceStation.Application.ApplicationUser;
using ServiceStation.Domain.Entities.Clients;
using ServiceStation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.ServiceStation.Commands.CreateCar
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly IServiceStationRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUserContext userContext;

        public CreateCarCommandHandler(IServiceStationRepository repository, IMapper mapper, IUserContext userContext)
        {
            _repository = repository;
            _mapper = mapper;
            this.userContext = userContext;
        }
        public async Task<Unit> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Car>(request);
            //var currentUser = userContext.GetCurrentUser();

            /*if (currentUser == null || !currentUser.IsInRole("Admin"))
            {
                return Unit.Value;
            }*/

            car.EncodeLicensePlate();

            //CreatedById = currentUser.Id;

            await _repository.Create(car);

            return Unit.Value;
        }
    }
}
