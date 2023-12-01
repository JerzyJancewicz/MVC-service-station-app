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
    public class ClientsRepository : IClientsRepository
    {
        private readonly ServiceStationDbContext _dbContext;

        public ClientsRepository(ServiceStationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _dbContext.client.ToListAsync();
        }
    }
}
