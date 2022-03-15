using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mission07.Models
{
    public class IdentitySeedData
    {
        // seed an admin username and password
        private const string adminUser = "Admin";
        private const string adminPassword = "413ExtraYeetPeriod(t)!";

        // this method creates the identity in the database if it doesn't already
        // exist. This is called each time the program is run as part of the
        // startup.cs file
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            // runs migrations if necessary
            AppIdentityDBContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            // creates the user
            IdentityUser user = await userManager.FindByIdAsync(adminUser);

            if (user == null)
            {
                user = new IdentityUser(adminUser);

                user.Email = "admin@blah.com";
                user.PhoneNumber = "333-333-5232";

                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
