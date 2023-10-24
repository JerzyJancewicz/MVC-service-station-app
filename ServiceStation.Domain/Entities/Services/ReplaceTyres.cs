using ServiceStation.Domain.Entities.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Domain.Entities.Services
{
    public class ReplaceTyres
    {
        public required int Id { get; set; }
        public string ServiceName { get;private set; } = "zmiana-opon";
        public string? Description { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ContactDetails contactDetails { get; set; } = default!;
        public string EncodedServiceName { get; private set; } = default!;

        public void EncodeName() => EncodedServiceName = ServiceName.ToLower().Replace(" ","-");
    }
}
