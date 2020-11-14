using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Data.EntitiesBuilders
{
    internal sealed class ClientGrantTypeBuilder : IEntityTypeConfiguration<ClientGrantType>
    {
        public void Configure(EntityTypeBuilder<ClientGrantType> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ClientId)
                .HasColumnName("CLIENT_ID");

            builder.Property(p => p.GrantType)
                .IsRequired()
                .HasColumnName("GRANT_TYPE")
                .HasMaxLength(250);

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.ClientId);

            builder.ToTable("CLIENT_GRANT_TYPES");

            builder.HasOne(p => p.Client)
                .WithMany(p => p.AllowedGrantTypes)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}