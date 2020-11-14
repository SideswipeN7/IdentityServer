using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Data.EntitiesBuilders
{
    internal sealed class ClientSecretBuilder : IEntityTypeConfiguration<ClientSecret>
    {
        public void Configure(EntityTypeBuilder<ClientSecret> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ClientId)
                .HasColumnName("CLIENT_ID");

            builder.Property(p => p.Created)
                .HasColumnName("CREATED");

            builder.Property(p => p.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(2000);

            builder.Property(p => p.Expiration)
                .HasColumnName("EXPIRATION");

            builder.Property(p => p.Type)
                .IsRequired()
                .HasColumnName("TYPE")
                .HasMaxLength(250);

            builder.Property(p => p.Value)
                .IsRequired()
                .HasColumnName("VALUE")
                .HasMaxLength(4000);

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.ClientId);

            builder.ToTable("CLIENT_SECRETS");

            builder.HasOne(p => p.Client)
                .WithMany(p => p.ClientSecrets)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}