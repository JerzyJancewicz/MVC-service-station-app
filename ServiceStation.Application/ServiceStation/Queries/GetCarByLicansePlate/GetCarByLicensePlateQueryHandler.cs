using AutoMapper;
using MediatR;
using ServiceStation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.ServiceStation.Queries.GetCarByLicansePlate
{
    public class GetCarByLicensePlateQueryHandler : IRequestHandler<GetCarByLicensePlateQuery, CarDto>
    {
        private readonly IServiceStationRepository repository;
        private readonly IMapper mapper;

        public GetCarByLicensePlateQueryHandler(IServiceStationRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<CarDto> Handle(GetCarByLicensePlateQuery request, CancellationToken cancellationToken)
        {
            var car = await repository.GetByName(request.LicensePlate);
            var carDto = mapper.Map<CarDto>(car);

            return carDto;
        }
    }
}
