using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Data.EntitiesBuilders
{
    internal sealed class ClientPropertyBuilder : IEntityTypeConfiguration<ClientProperty>
    {
        public void Configure(EntityTypeBuilder<ClientProperty> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ClientId)
                .HasColumnName("CLIENT_ID");

            builder.Property(p => p.Key)
                .IsRequired()
                .HasColumnName("KEY")
                .HasMaxLength(250);

            builder.Property(p => p.Value)
                .IsRequired()
                .HasColumnName("VALUE")
                .HasMaxLength(2000);

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.ClientId);

            builder.ToTable("CLIENT_PROPERTIES");

            builder.HasOne(p => p.Client)
                .WithMany(p => p.Properties)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}