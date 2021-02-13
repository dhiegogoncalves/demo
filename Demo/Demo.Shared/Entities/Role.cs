﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Demo.Shared.Entities
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
