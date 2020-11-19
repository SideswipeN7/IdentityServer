using EfCoreBuilders = Microsoft.EntityFrameworkCore.Metadata.Builders;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth.Grants.Database.EntitiesBuilders
{
    internal sealed class PersistedGrantBuilder : IEntityTypeConfiguration<PersistedGrant>
    {
        public void Configure(EfCoreBuilders.EntityTypeBuilder<PersistedGrant> builder)
        {
            builder.Property(p => p.Key)
                .HasColumnName("KEY")
                .HasMaxLength(200);

            builder.Property(p => p.ClientId)
                .HasColumnName("CLIENT_ID")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.ConsumedTime)
                .HasColumnName("CONSUMED_TIME");

            builder.Property(p => p.CreationTime)
                .HasColumnName("CREATION_TIME");

            builder.Property(p => p.Data)
                .HasColumnName("DATA")
                .IsRequired()
                .HasMaxLength(50000);

            builder.Property(p => p.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(200);

            builder.Property(p => p.Expiration)
                .HasColumnName("EXPIRATION")
                .IsRequired();

            builder.Property(p => p.SessionId)
                .HasColumnName("SESSION_ID")
                .HasMaxLength(100);

            builder.Property(p => p.SubjectId)
                .HasColumnName("SUBJECT_ID")
                .HasMaxLength(200);

            builder.Property(p => p.Type)
                .HasColumnName("TYPE")
                .IsRequired()
                .HasMaxLength(50);

            builder.HasKey(p => p.Key);

            builder.HasIndex(p => p.Expiration);

            builder.HasIndex(p => new { p.SubjectId, p.ClientId, p.Type });

            builder.HasIndex(p => new { p.SubjectId, p.SessionId, p.Type });

            builder.ToTable("PERSISTED_GRANTS");
        }
    }
}