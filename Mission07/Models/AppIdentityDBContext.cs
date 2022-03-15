using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mission07.Models
{
    public class AppIdentityDBContext : IdentityDbContext<IdentityUser>
    {
        // create a context file for the new Identity database
        public AppIdentityDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
