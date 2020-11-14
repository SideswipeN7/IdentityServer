using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Data.EntitiesBuilders
{
    internal sealed class ApiResourceSecretBuilder : IEntityTypeConfiguration<ApiResourceSecret>
    {
        public void Configure(EntityTypeBuilder<ApiResourceSecret> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ApiResourceId)
                .HasColumnName("API_RESOURCE_ID");

            builder.Property(p => p.Created)
                .HasColumnName("CREATED");

            builder.Property(p => p.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(1000);

            builder.Property(p => p.Expiration)
                .HasColumnName("EXPIRATION");

            builder.Property(p => p.Type)
                .IsRequired()
                .HasColumnName("TYPE")
                .HasMaxLength(250);

            builder.Property(p => p.Value)
                .HasColumnName("VALUE");

            builder.HasKey(P => P.Id);

            builder.HasIndex(P => P.ApiResourceId)
                .IsUnique();

            builder.ToTable("API_RESOURCE_SECRETS");

            builder.HasOne(p => p.ApiResource)
                .WithMany(p => p.Secrets)
                .HasForeignKey(p => p.ApiResourceId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}