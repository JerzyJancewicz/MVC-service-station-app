using AutoMapper;
using MediatR;
using ServiceStation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.ServiceStation.Queries.GetAllCar
{
    public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, IEnumerable<CarDto>>
    {
        private readonly IMapper _mapper;
        private readonly IServiceStationRepository _repository;

        public GetAllCarQueryHandler(IMapper mapper, IServiceStationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<CarDto>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            var cars = await _repository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CarDto>>(cars);

            return dtos;
        }
    }
}
