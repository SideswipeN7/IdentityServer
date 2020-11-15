using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Configuration.Database.EntitiesBuilders
{
    internal sealed class ApiScopePropertyBuilder : IEntityTypeConfiguration<ApiScopeProperty>
    {
        public void Configure(EntityTypeBuilder<ApiScopeProperty> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Key)
                .IsRequired()
                .HasColumnName("KEY")
                .HasMaxLength(250);

            builder.Property(p => p.ScopeId)
                .HasColumnName("SCOPE_ID");

            builder.Property(p => p.Value)
                .IsRequired()
                .HasColumnName("VALUE")
                .HasMaxLength(2000);

            builder.HasKey(P => P.Id);

            builder.HasIndex(P => P.ScopeId);

            builder.ToTable("API_SCOPE_PROPERTIES");

            builder.HasOne(p => p.Scope)
                .WithMany(p => p.Properties)
                .HasForeignKey(p => p.ScopeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}