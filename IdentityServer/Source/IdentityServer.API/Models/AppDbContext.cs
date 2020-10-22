using Microsoft.EntityFrameworkCore;

namespace IdentityServer.API.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public AppDbContext(DbContextOptions<DbContext> options) : base(options)
        {}
    }
}