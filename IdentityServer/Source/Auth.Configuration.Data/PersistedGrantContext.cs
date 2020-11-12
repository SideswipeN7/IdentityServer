using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace Auth.Data
{
    public class PersistedGrantContext : PersistedGrantDbContext
    {
        public PersistedGrantContext(DbContextOptions<PersistedGrantDbContext> options, OperationalStoreOptions storeOptions)
            : base(options, storeOptions)
        { }
    }
}