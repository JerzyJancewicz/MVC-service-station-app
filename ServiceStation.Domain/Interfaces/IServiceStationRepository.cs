using ServiceStation.Domain.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Domain.Interfaces
{
    public interface IServiceStationRepository
    {
        Task Create(CarDto car);
    }
}
