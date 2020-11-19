using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Grants.Database.EntitiesBuilders
{
    internal sealed class DeviceFlowCodesBuilder : IEntityTypeConfiguration<DeviceFlowCodes>
    {
        public void Configure(EntityTypeBuilder<DeviceFlowCodes> builder)
        {
            builder.Property(p => p.UserCode)
                .HasColumnName("USER_CODE")
                .HasMaxLength(200);

            builder.Property(p => p.ClientId)
                .HasColumnName("CLIENT_ID")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.CreationTime)
                .HasColumnName("CREATION_TIME");

            builder.Property(p => p.Data)
                .HasColumnName("DATA")
                .IsRequired()
                .HasMaxLength(50000);

            builder.Property(p => p.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(200);

            builder.Property(p => p.DeviceCode)
                .HasColumnName("DEVICE_CODE")
                .IsRequired()
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

            builder.HasKey(p => p.UserCode);

            builder.HasIndex(p => p.DeviceCode)
                .IsUnique();

            builder.HasIndex(p => p.Expiration);

            builder.ToTable("DEVICE_CODES");
        }
    }
}