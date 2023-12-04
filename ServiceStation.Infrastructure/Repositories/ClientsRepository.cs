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

        public async Task CreateClient(Client client)
        {
            _dbContext.Add(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _dbContext.client.ToListAsync();
        }

        public async Task<Client?> GetByName(int Id)
        {
            return await _dbContext.client.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Update(Client client)
        {
            var currentClient = await _dbContext.client.FirstOrDefaultAsync(e => e.Id == client.Id);
            if (currentClient != null)
            {
                currentClient.ContactDetails.Name = client.ContactDetails.Name;
                currentClient.ContactDetails.Surname = client.ContactDetails.Surname;
                currentClient.ContactDetails.PhoneNumber = client.ContactDetails.PhoneNumber;
                currentClient.ContactDetails.Email = client.ContactDetails.Email;
                currentClient.ContactDetails.Street = client.ContactDetails.Street;
                currentClient.ContactDetails.City = client.ContactDetails.City;
                currentClient.ContactDetails.PostalCode = client.ContactDetails.PostalCode;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteClient(int Id)
        {
            var client = await _dbContext.client.FirstOrDefaultAsync(e => e.Id == Id);
            if (client != null)
            {
                _dbContext.client.Remove(client);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
