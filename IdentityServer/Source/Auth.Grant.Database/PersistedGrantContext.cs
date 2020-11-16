using Microsoft.EntityFrameworkCore;

namespace Auth.Grant.Database
{
    public class PersistedGrantContext: DbContext
    {
        public PersistedGrantContext(DbContextOptions<PersistedGrantContext> options): base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersistedGrantContext).Assembly);
        }
    }
}