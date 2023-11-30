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
        Task Create(Car car);
        Task<Car?> GetByName(string name);
        Task<IEnumerable<Car>> GetAll();
        Task Update(Car car);
        Task<Client?> GetClientById(int Id);
        Task DeleteCar(string LicensePlate);
    }
}
