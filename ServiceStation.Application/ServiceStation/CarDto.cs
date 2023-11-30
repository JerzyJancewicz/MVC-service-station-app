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
        public string CarName { get; set; } = default!;
        public int IdClient { get; set; }
        public bool IsEditable { get; set; }
    }
}
