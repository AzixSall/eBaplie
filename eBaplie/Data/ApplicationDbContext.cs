using eBaplie.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eBaplie.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vessel>? Vessels { get; set; }
        public DbSet<EdifactGlobal>? EdifactGlobals { get; set; }
        public DbSet<EdiChangeLog>? EdiChangeLogs { get; set; }
        public DbSet<BaplieRequirement>? BaplieRequirements { get; set; }
        public DbSet<eBaplie.Models.Voyage> Voyage { get; set; }
        public DbSet<eBaplie.Models.Log>? Logs { get; set; }
    }
}