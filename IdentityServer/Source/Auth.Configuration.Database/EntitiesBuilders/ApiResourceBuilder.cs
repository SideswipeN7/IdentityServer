using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Configuration.Database.EntitiesBuilders
{
    internal sealed class ApiResourceBuilder : IEntityTypeConfiguration<ApiResource>
    {
        public void Configure(EntityTypeBuilder<ApiResource> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.AllowedAccessTokenSigningAlgorithms)
                .HasColumnName("ALLOWED_ACCESS_TOKEN_SIGNING_ALGORITHMS")
                .HasMaxLength(100);

            builder.Property(p => p.Created)
                .HasColumnName("CREATED");

            builder.Property(p => p.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(1000);

            builder.Property(P => P.DisplayName)
                .HasColumnName("DISPLAY_NAME")
                .HasMaxLength(200);

            builder.Property(p => p.Enabled)
                .HasColumnName("ENABLED");

            builder.Property(p => p.LastAccessed)
                .HasColumnName("LAST_ACCESSED");

            builder.Property(p => p.Name)
                .HasColumnName("NAME")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.NonEditable)
                .HasColumnName("NON_EDITABLE");

            builder.Property(p => p.ShowInDiscoveryDocument)
                .HasColumnName("SHOW_IN_DISCOVERY_DOCUMENT");

            builder.Property(p => p.Updated)
                .HasColumnName("UPDATED");

            builder.HasKey(P => P.Id);

            builder.HasIndex(P => P.Name)
                .IsUnique();

            builder.ToTable("API_RESOURCES");
        }
    }
}