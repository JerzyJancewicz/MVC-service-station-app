using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.ServiceStation.Queries.GetAllCar
{
    public class GetAllCarQuery : IRequest<IEnumerable<CarDto>>
    {

    }
}
