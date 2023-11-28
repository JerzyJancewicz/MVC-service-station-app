using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.ServiceStation.Queries.GetCarByLicansePlate
{
    public class GetCarByLicensePlateQuery : IRequest<CarDto>
    {
        public string LicensePlate;

        public GetCarByLicensePlateQuery(string licensePlate)
        {
            LicensePlate = licensePlate;
        }
    }
}
