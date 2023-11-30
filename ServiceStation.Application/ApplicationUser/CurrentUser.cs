using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.ApplicationUser
{
    public class CurrentUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public CurrentUser(string email, string id, IEnumerable<string> roles)
        {
            Email = email;
            Id = id;
            Roles = roles;
        }

        public bool IsInRole(string role) => Roles.Contains(role);
    }
}
