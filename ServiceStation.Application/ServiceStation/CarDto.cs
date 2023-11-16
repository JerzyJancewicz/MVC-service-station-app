using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.ServiceStation
{
    public class CarDto
    {
        public required string LicensePlate { get; set; }
        public string Name { get; set; } = default!;
        

    }
}
