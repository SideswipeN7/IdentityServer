using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Configuration.Database.EntitiesBuilders
{
    internal sealed class IdentityResourceBuilder : IEntityTypeConfiguration<IdentityResource>
    {
        public void Configure(EntityTypeBuilder<IdentityResource> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Created)
                .HasColumnName("CREATED");

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

            builder.Property(p => p.NonEditable)
                .HasColumnName("NON_EDITABLE");

            builder.Property(p => p.Required)
                .HasColumnName("REQUIRED");

            builder.Property(p => p.ShowInDiscoveryDocument)
                .HasColumnName("SHOW_IN_DISCOVERY_DOCUMENT");

            builder.Property(p => p.Updated)
                .HasColumnName("UPDATED");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Name)
                .IsUnique();

            builder.ToTable("IDENTITY_RESOURCES");
        }
    }
}