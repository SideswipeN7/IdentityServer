using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Data.EntitiesBuilders
{
    internal sealed class IdentityResourcePropertyBuilder : IEntityTypeConfiguration<IdentityResourceProperty>
    {
        public void Configure(EntityTypeBuilder<IdentityResourceProperty> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdentityResourceId)
                .HasColumnName("IDENTITY_RESOURCE_ID");

            builder.Property(p => p.Key)
                .IsRequired()
                .HasColumnName("KEY")
                .HasMaxLength(250);

            builder.Property(p => p.Value)
                .IsRequired()
                .HasColumnName("VALUE")
                .HasMaxLength(2000);

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.IdentityResourceId);

            builder.ToTable("IDENTITY_RESOURCE_PROPERTIES");

            builder.HasOne(p => p.IdentityResource)
                .WithMany(p => p.Properties)
                .HasForeignKey(p => p.IdentityResourceId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}