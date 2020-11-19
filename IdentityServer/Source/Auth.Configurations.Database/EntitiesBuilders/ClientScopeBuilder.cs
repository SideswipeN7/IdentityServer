using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Configurations.Database.EntitiesBuilders
{
    internal sealed class ClientScopeBuilder : IEntityTypeConfiguration<ClientScope>
    {
        public void Configure(EntityTypeBuilder<ClientScope> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ClientId)
                .HasColumnName("CLIENT_ID");

            builder.Property(p => p.Scope)
                .IsRequired()
                .HasColumnName("SCOPE")
                .HasMaxLength(200);

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.ClientId);

            builder.ToTable("CLIENT_SCOPES");

            builder.HasOne(p => p.Client)
                .WithMany(p => p.AllowedScopes)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}