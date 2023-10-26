using ServiceStation.Domain.Entities.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Domain.Entities.Users
{
    public class User
    {
        public required int Id { get; set; }
        public int IdContacDetails { get; set; }
        public virtual ContactDetails IdContactDetailsNavigation { get; set; } = default!;
    }
}
