using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Configurations.Database.EntitiesBuilders
{
    internal sealed class ClientCorsOriginBuilder : IEntityTypeConfiguration<ClientCorsOrigin>
    {
        public void Configure(EntityTypeBuilder<ClientCorsOrigin> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ClientId)
                .HasColumnName("CLIENT_ID");

            builder.Property(p => p.Origin)
                .IsRequired()
                .HasColumnName("ORIGIN")
                .HasMaxLength(150);

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.ClientId);

            builder.ToTable("CLIENT_CORS_ORIGINS");

            builder.HasOne(p => p.Client)
                .WithMany(p => p.AllowedCorsOrigins)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}