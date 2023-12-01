using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Clients.Queries.GetAllClients
{
    public class GetAllClientsQuery : IRequest<IEnumerable<ClientDto>>
    {
    }
}
