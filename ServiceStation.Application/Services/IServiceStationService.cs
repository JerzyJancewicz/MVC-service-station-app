using ServiceStation.Application.ServiceStation;
using ServiceStation.Domain.Entities.Clients;

namespace ServiceStation.Application.Services
{
    public interface IServiceStationService
    {
        Task Create(CarDto car);
        Task<IEnumerable<CarDto>> GetAll();

    }
}