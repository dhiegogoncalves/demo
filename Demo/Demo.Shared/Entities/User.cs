using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Demo.Shared.Entities
{
    public class User : IdentityUser<int>
    {
        public bool Active { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
