using AutoMapper;
using MediatR;
using ServiceStation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.ServiceStation.Queries.GetAllClientsCar
{
    public class GetAllClientsCarQueryHandler : IRequestHandler<GetAllClientsCarQuery, IEnumerable<CarDto>>
    {
        private readonly IServiceStationRepository _repository;
        private readonly IMapper _mapper;

        public GetAllClientsCarQueryHandler(IServiceStationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CarDto>> Handle(GetAllClientsCarQuery request, CancellationToken cancellationToken)
        {
            var clientCars = await _repository.GetAllClientCars(request._Id);
            var clienCarsDto = _mapper.Map<IEnumerable<CarDto>>(clientCars);

            return clienCarsDto;
        }
    }
}
