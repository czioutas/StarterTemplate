using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarterTemplate.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset DeletedAt { get; set; } = DateTimeOffset.UtcNow;
        public Boolean Deleted { get; set; } = false;
    }
}
