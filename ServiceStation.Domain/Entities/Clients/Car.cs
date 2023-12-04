using Microsoft.AspNetCore.Identity;
using ServiceStation.Domain.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Domain.Entities.Clients
{
    public class Car
    {
        public required string LicensePlate { get; set; }
        public string CarName { get; set; } = default!;
        public int IdClient { get; set; }
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }
        /*public virtual Client IdClientNavigation { get; set; } = null!;
        public virtual ICollection<Service> Services { get; set; } = new List<Service>();
*/
        public void EncodeLicensePlate() => LicensePlate = LicensePlate.ToUpper().Replace(" ", "");
    }
}
