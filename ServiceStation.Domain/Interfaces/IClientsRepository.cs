using ServiceStation.Domain.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Domain.Interfaces
{
    public interface IClientsRepository
    {
        Task<IEnumerable<Client>> GetAll();
        Task CreateClient(Client client);
        Task<Client?> GetByName(int Id);
        Task Update(Client client);
        Task DeleteClient(int Id);
    }
}
