using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Configurations.Database.EntitiesBuilders
{
    internal sealed class ApiScopeBuilder : IEntityTypeConfiguration<ApiScope>
    {
        public void Configure(EntityTypeBuilder<ApiScope> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(1000);

            builder.Property(p => p.DisplayName)
                .HasColumnName("DISPLAY_NAME")
                .HasMaxLength(200);

            builder.Property(p => p.Emphasize)
                .HasColumnName("EMPHASIZE");

            builder.Property(p => p.Enabled)
                .HasColumnName("ENABLED");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("NAME")
                .HasMaxLength(200);

            builder.Property(p => p.Required)
                .HasColumnName("REQUIRED");

            builder.Property(p => p.ShowInDiscoveryDocument)
                .HasColumnName("SHOW_IN_DISCOVERY_DOCUMENT");

            builder.HasKey(P => P.Id);

            builder.HasIndex(P => P.Name)
                .IsUnique();

            builder.ToTable("API_SCOPES");
        }
    }
}