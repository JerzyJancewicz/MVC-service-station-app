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

namespace ServiceStation.Application.ServiceStation.Commands.UpdateCar
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
    {
        private readonly IServiceStationRepository repository;
        private readonly IMapper mapper;
        private readonly IUserContext userContext;

        public UpdateCarCommandHandler(IServiceStationRepository repository, IMapper mapper, IUserContext userContext)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.userContext = userContext;
        }
        public async Task<Unit> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            //var currentCar = await repository.GetByName(request.CarName);
            //var user = userContext.GetCurrentUser();
            /*var isEditable = user != null || currentCar?.CreatedById == user?.Id;

            if (!isEditable)
            {
                return Unit.Value;
            }*/

            var car = mapper.Map<Car>(request);
            await repository.Update(car);
            return Unit.Value;
        }
    }
}
