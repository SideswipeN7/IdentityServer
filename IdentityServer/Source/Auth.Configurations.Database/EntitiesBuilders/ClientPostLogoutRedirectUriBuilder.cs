using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Configurations.Database.EntitiesBuilders
{
    internal sealed class ClientPostLogoutRedirectUriBuilder : IEntityTypeConfiguration<ClientPostLogoutRedirectUri>
    {
        public void Configure(EntityTypeBuilder<ClientPostLogoutRedirectUri> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ClientId)
                .HasColumnName("CLIENT_ID");

            builder.Property(p => p.PostLogoutRedirectUri)
                .IsRequired()
                .HasColumnName("POST_LOGOUT_REDIRECT_URI")
                .HasMaxLength(2000);

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.ClientId);

            builder.ToTable("CLIENT_POST_LOGOUT_REDIRECT_URIS");

            builder.HasOne(p => p.Client)
                .WithMany(p => p.PostLogoutRedirectUris)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}