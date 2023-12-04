using ServiceStation.Domain.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Domain.Entities.Services
{
    public class Service
    {
        public required int Id { get; set; }
        public string? Description { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public int IdServiceType { get; set; }
        public string CarLicensePlate { get; set; } = default!;
/*        public virtual Service_Type IdServiceTypeNavigation { get; set; } = null!;
        public virtual Car IdCarNavigation { get; set; } = null!;*/
    }
}
