using ServiceStation.Application.ServiceStation;
using ServiceStation.Domain.Entities.Clients;
using ServiceStation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Services
{
    public class ServiceStationService : IServiceStationService
    {
        private readonly IServiceStationRepository serviceStationRepository;

        public ServiceStationService(IServiceStationRepository serviceStationRepository)
        {
            this.serviceStationRepository = serviceStationRepository;
        }
        public async Task Create(CarDto car)
        {
            await serviceStationRepository.Create(car);
        }
    }
}
