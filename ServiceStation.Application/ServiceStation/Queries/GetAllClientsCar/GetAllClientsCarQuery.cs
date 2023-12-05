using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.ServiceStation.Queries.GetAllClientsCar
{
    public class GetAllClientsCarQuery : IRequest<IEnumerable<CarDto>>
    {
        public int _Id;
        public GetAllClientsCarQuery(int Id)
        {
            _Id = Id;
        }
    }
}
