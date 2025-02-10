using Copify.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Copify.AppliocatioDbContext
{
    public class AppDataContext : IdentityDbContext<AppUser>
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>(){
                new IdentityRole{Id="Admin",Name="Admin",NormalizedName="ADMIN"},
                new IdentityRole{Id="User",Name="User",NormalizedName="USER"}
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
