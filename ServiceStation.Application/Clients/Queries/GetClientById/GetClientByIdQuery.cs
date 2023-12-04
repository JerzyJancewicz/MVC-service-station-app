using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Clients.Queries.GetClientById
{
    public class GetClientByIdQuery : IRequest<ClientDto>
    {
        public int Id { get; set; }

        public GetClientByIdQuery(int id)
        {
            Id = id;
        }
    }
}
