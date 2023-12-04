using ServiceStation.Domain.Entities.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Domain.Entities.Clients
{
    public class Client
    {
        public required int Id { get; set; }
        public int ContactDetailsId { get; set; }
        public required ContactDetails ContactDetails { get; set; }
        /*public int IdContactDetails { get; set; }
        public virtual ContactDetails IdContactDetailsNavigation { get; set; } = null!;
        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();*/
    }
}
