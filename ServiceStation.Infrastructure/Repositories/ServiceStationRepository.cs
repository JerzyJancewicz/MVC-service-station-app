using Microsoft.EntityFrameworkCore;
using ServiceStation.Domain.Entities.Clients;
using ServiceStation.Domain.Interfaces;
using ServiceStation.Infrastructure.Presistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Infrastructure.Repositories
{
    internal class ServiceStationRepository : IServiceStationRepository
    {
        private readonly ServiceStationDbContext _serviceStationDbContext;
        public ServiceStationRepository(ServiceStationDbContext serviceStationDbContext)
        {
            _serviceStationDbContext = serviceStationDbContext;
        }

        public async Task Create(Car car)
        {
            _serviceStationDbContext.Add(car);
            await _serviceStationDbContext.SaveChangesAsync();
        }

        public async Task DeleteCar(string LicensePlate)
        {
            var car = await _serviceStationDbContext.car.FirstOrDefaultAsync(e => e.LicensePlate == LicensePlate);
            if (car != null)
            {
                _serviceStationDbContext.car.Remove(car);
                await _serviceStationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _serviceStationDbContext.car.ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetAllClientCars(int Id)
        {
            var cars = await _serviceStationDbContext.car.Where(e => e.IdClient == Id).ToListAsync();
            return cars;
        }

        public async Task<Car?> GetByName(string name)
        {
            return await _serviceStationDbContext.car.FirstOrDefaultAsync(e => e.LicensePlate.ToLower() == name.ToLower());
        }

        public async Task<Client?> GetClientById(int Id)
        {
            return await _serviceStationDbContext.client.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task Update(Car car)
        {
            var carToUpdate = await _serviceStationDbContext.car.FirstOrDefaultAsync(e => e.LicensePlate.ToLower() == car.LicensePlate.ToLower());
            if (carToUpdate != null)
            {
                carToUpdate.CarName = car.CarName;
                carToUpdate.IdClient = car.IdClient;
                await _serviceStationDbContext.SaveChangesAsync();
            }
        }
    }
}
