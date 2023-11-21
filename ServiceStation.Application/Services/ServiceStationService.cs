using AutoMapper;
using ServiceStation.Application.ServiceStation;
using ServiceStation.Domain.Entities.Clients;
using ServiceStation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Services
{
    public class ServiceStationService : IServiceStationService
    {
        private readonly IServiceStationRepository serviceStationRepository;
        private readonly IMapper mapper;

        public ServiceStationService(IServiceStationRepository serviceStationRepository, IMapper mapper)
        {
            this.serviceStationRepository = serviceStationRepository;
            this.mapper = mapper;
        }
        public async Task Create(CarDto carDto)
        {
            //right to left
            var car = mapper.Map<Car>(carDto);

            car.EncodeLicensePlate();
            await serviceStationRepository.Create(car);
        }

        public async Task<IEnumerable<CarDto>> GetAll()
        {
            var cars = await serviceStationRepository.GetAll();
            var dtos = mapper.Map<IEnumerable<CarDto>>(cars);

            return dtos;
        }
    }
}
