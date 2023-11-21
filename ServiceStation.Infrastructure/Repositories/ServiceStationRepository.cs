﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _serviceStationDbContext.car.ToListAsync();
        }

        public async Task<Car?> GetByName(string name)
        {
            return await _serviceStationDbContext.car.FirstOrDefaultAsync(e => e.LicensePlate.ToLower() == name.ToLower());
        }
    }
}
