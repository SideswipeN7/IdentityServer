using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Configurations.Database.EntitiesBuilders
{
    internal sealed class ApiResourcePropertyBuilder : IEntityTypeConfiguration<ApiResourceProperty>
    {
        public void Configure(EntityTypeBuilder<ApiResourceProperty> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ApiResourceId)
                .HasColumnName("API_RESOURCE_ID");

            builder.Property(p => p.Key)
                .IsRequired()
                .HasColumnName("KEY")
                .HasMaxLength(250);

            builder.Property(p => p.Value)
                .IsRequired()
                .HasColumnName("VALUE")
                .HasMaxLength(2000);

            builder.HasKey(P => P.Id);

            builder.HasIndex(P => P.ApiResourceId);

            builder.ToTable("API_RESOURCE_PROPERTIES");

            builder.HasOne(p => p.ApiResource)
                .WithMany(p => p.Properties)
                .HasForeignKey(p => p.ApiResourceId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}