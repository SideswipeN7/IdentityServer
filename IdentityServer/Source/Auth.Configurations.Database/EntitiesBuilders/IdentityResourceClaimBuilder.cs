using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Configurations.Database.EntitiesBuilders
{
    internal sealed class IdentityResourceClaimBuilder : IEntityTypeConfiguration<IdentityResourceClaim>
    {
        public void Configure(EntityTypeBuilder<IdentityResourceClaim> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdentityResourceId)
                .HasColumnName("IDENTITY_RESOURCE_ID");

            builder.Property(p => p.Type)
                .IsRequired()
                .HasColumnName("TYPE")
                .HasMaxLength(200);

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.IdentityResourceId);

            builder.ToTable("IDENTITY_RESOURCE_CLAIMS");

            builder.HasOne(p => p.IdentityResource)
                .WithMany(p => p.UserClaims)
                .HasForeignKey(p => p.IdentityResourceId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}