using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Domain.Entities.Services
{
    public class Service_Type
    {
        public required int Id { get; set; }
        public string ServiceName { get; private set; } = default!;
        public TimeSpan ServiceTime { get; set; }
        public string EncodedServiceName { get; private set; } = default!;
        public void EncodeName() => EncodedServiceName = ServiceName.ToLower().Replace(" ", "-");
        /*public virtual ICollection<Service> Services { get; set; } = new List<Service>();*/

    }
}
