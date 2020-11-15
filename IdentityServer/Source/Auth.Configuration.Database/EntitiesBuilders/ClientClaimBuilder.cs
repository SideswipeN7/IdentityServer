using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Configuration.Database.EntitiesBuilders
{
    internal sealed class ClientClaimBuilder : IEntityTypeConfiguration<ClientClaim>
    {
        public void Configure(EntityTypeBuilder<ClientClaim> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ClientId)
                .HasColumnName("CLIENT_ID");

            builder.Property(p => p.Type)
                .IsRequired()
                .HasColumnName("TYPE")
                .HasMaxLength(250);

            builder.Property(p => p.Value)
                .IsRequired()
                .HasColumnName("VALUE")
                .HasMaxLength(250);

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.ClientId);

            builder.ToTable("CLIENT_CLAIMS");

            builder.HasOne(p => p.Client)
                .WithMany(p => p.Claims)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}