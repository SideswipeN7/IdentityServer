using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Configurations.Database.EntitiesBuilders
{
    internal sealed class ApiResourceClaimBuilder : IEntityTypeConfiguration<ApiResourceClaim>
    {
        public void Configure(EntityTypeBuilder<ApiResourceClaim> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ApiResourceId)
                .HasColumnName("API_RESOURCE_ID");

            builder.Property(p => p.Type)
                .HasColumnName("TYPE")
                .IsRequired()
                .HasMaxLength(200);

            builder.HasKey(P => P.Id);

            builder.HasIndex(P => P.ApiResourceId);

            builder.ToTable("API_RESOURCE_CLAIMS");

            builder.HasOne(p => p.ApiResource)
                .WithMany(p => p.UserClaims)
                .HasForeignKey(p => p.ApiResourceId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}