using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.ServiceStation
{
    public class CarDto
    {
        public string LicensePlate { get; set; } = default!;
        public string Name { get; set; } = default!;
        

    }
}
