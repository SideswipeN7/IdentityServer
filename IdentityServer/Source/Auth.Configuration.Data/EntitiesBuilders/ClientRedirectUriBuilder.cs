using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Data.EntitiesBuilders
{
    internal sealed class ClientRedirectUriBuilder : IEntityTypeConfiguration<ClientRedirectUri>
    {
        public void Configure(EntityTypeBuilder<ClientRedirectUri> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ClientId)
                .HasColumnName("CLIENT_ID");

            builder.Property(p => p.RedirectUri)
                .IsRequired()
                .HasColumnName("REDIRECT_URI")
                .HasMaxLength(2000);

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.ClientId);

            builder.ToTable("CLIENT_REDIRECT_URIS");

            builder.HasOne(p => p.Client)
                .WithMany(p => p.RedirectUris)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}