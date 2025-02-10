using Copify.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Copify.AppliocatioDbContext
{
    public class AppDataContext:IdentityDbContext<AppUser>
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }
    }
}
