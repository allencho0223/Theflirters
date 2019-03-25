using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace D8M8.API.Models
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}