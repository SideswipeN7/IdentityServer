using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Configuration.Database.EntitiesBuilders
{
    internal sealed class ApiScopeClaimBuilder : IEntityTypeConfiguration<ApiScopeClaim>
    {
        public void Configure(EntityTypeBuilder<ApiScopeClaim> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ScopeId)
                .HasColumnName("SCOPE_ID");

            builder.Property(p => p.Type)
                .IsRequired()
                .HasColumnName("TYPE")
                .HasMaxLength(200);

            builder.HasKey(P => P.Id);

            builder.HasIndex(P => P.ScopeId);

            builder.ToTable("API_SCOPE_CLAIMS");

            builder.HasOne(p => p.Scope)
                .WithMany(p => p.UserClaims)
                .HasForeignKey(p => p.ScopeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}