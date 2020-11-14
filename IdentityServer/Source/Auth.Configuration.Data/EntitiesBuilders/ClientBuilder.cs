using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Data.EntitiesBuilders
{
    internal sealed class ClientBuilder : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.AbsoluteRefreshTokenLifetime)
                .HasColumnName("ABSOLUTE_REFRESH_TOKEN_LIFETIME");

            builder.Property(p => p.AccessTokenLifetime)
                .HasColumnName("ACCESS_TOKEN_LIFETIME");

            builder.Property(p => p.AccessTokenType)
                .HasColumnName("AccessTokenType");

            builder.Property(p => p.AllowAccessTokensViaBrowser)
                .HasColumnName("ALLOW_ACCESS_TOKENS_VIA_BROWSER");

            builder.Property(p => p.AllowOfflineAccess)
                .HasColumnName("ALLOW_OFFLINE_ACCESS");

            builder.Property(p => p.AllowPlainTextPkce)
                .HasColumnName("ALLOW_PLAIN_TEXT_PKCE");

            builder.Property(p => p.AllowRememberConsent)
                .HasColumnName("ALLOW_REMEMBER_CONSENT");

            builder.Property(p => p.AllowedIdentityTokenSigningAlgorithms)
                .HasColumnName("ALLOWED_IDENTITY_TOKEN_SIGNING_ALGORITHMS")
                .HasMaxLength(100);

            builder.Property(p => p.AlwaysIncludeUserClaimsInIdToken)
                .HasColumnName("ALWAYS_INCLUDE_USER_CLAIMS_IN_ID_TOKEN");

            builder.Property(p => p.AlwaysSendClientClaims)
                .HasColumnName("ALWAYS_SEND_CLIENT_CLAIMS");

            builder.Property(p => p.AuthorizationCodeLifetime)
                .HasColumnName("AUTHORIZATION_CODE_LIFETIME");

            builder.Property(p => p.BackChannelLogoutSessionRequired)
                .HasColumnName("BACK_CHANNEL_LOGOUT_SESSION_REQUIRED");

            builder.Property(p => p.BackChannelLogoutUri)
                .HasColumnName("BACK_CHANNEL_LOGOUT_URI")
                .HasMaxLength(2000);

            builder.Property(p => p.ClientClaimsPrefix)
                .HasColumnName("CLIENT_CLAIMS_PREFIX")
                .HasMaxLength(200);

            builder.Property(p => p.ClientId)
                .HasColumnName("CLIENT_ID")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.ClientName)
                .HasColumnName("CLIENT_NAME")
                .HasMaxLength(200);

            builder.Property(p => p.ClientUri)
                .HasColumnName("CLIENT_URI")
                .HasMaxLength(2000);

            builder.Property(p => p.ConsentLifetime)
                .HasColumnName("CONSENT_LIFETIME");

            builder.Property(p => p.Created)
                .HasColumnName("CREATED");

            builder.Property(p => p.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(1000);

            builder.Property(p => p.DeviceCodeLifetime)
                .HasColumnName("DEVICE_CODE_LIFETIME");

            builder.Property(p => p.EnableLocalLogin)
                .HasColumnName("ENABLE_LOCAL_LOGIN");

            builder.Property(p => p.Enabled)
                .HasColumnName("ENABLED");

            builder.Property(p => p.FrontChannelLogoutSessionRequired)
                .HasColumnName("FRONT_CHANNEL_LOGOUT_SESSION_REQUIRED");

            builder.Property(p => p.FrontChannelLogoutUri)
                .HasColumnName("FRONT_CHANNEL_LOGOUT_URI")
                .HasMaxLength(2000);

            builder.Property(p => p.IdentityTokenLifetime)
                .HasColumnName("IDENTITY_TOKEN_LIFETIME");

            builder.Property(p => p.IncludeJwtId)
                .HasColumnName("INCLUDE_JWT_ID");

            builder.Property(p => p.LastAccessed)
                .HasColumnName("LAST_ACCESSED");

            builder.Property(p => p.LogoUri)
                .HasColumnName("LOGO_URI")
                .HasMaxLength(2000);

            builder.Property(p => p.NonEditable)
                .HasColumnName("NON_EDITABLE");

            builder.Property(p => p.PairWiseSubjectSalt)
                .HasColumnName("PAIR_WISE_SUBJECT_SALT")
                .HasMaxLength(200);

            builder.Property(p => p.ProtocolType)
                .HasColumnName("PROTOCOL_TYPE")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.RefreshTokenExpiration)
                .HasColumnName("REFRESH_TOKEN_EXPIRATION");

            builder.Property(p => p.RefreshTokenUsage)
                .HasColumnName("REFRESH_TOKEN_USAGE");

            builder.Property(p => p.RequireClientSecret)
                .HasColumnName("REQUIRE_CLIENT_SECRET");

            builder.Property(p => p.RequireConsent)
                .HasColumnName("REQUIRE_CONSENT");

            builder.Property(p => p.RequirePkce)
                .HasColumnName("REQUIRE_PKCE");

            builder.Property(p => p.RequireRequestObject)
                .HasColumnName("REQUIRE_REQUEST_OBJECT");

            builder.Property(p => p.SlidingRefreshTokenLifetime)
                .HasColumnName("SLIDING_REFRESH_TOKEN_LIFETIME");

            builder.Property(p => p.UpdateAccessTokenClaimsOnRefresh)
                .HasColumnName("UPDATE_ACCESS_TOKEN_CLAIMS_ON_REFRESH");

            builder.Property(p => p.Updated)
                .HasColumnName("UPDATED");

            builder.Property(p => p.UserCodeType)
                .HasColumnName("USER_CODE_TYPE")
                .HasMaxLength(100);

            builder.Property(p => p.UserSsoLifetime)
                .HasColumnName("USER_SSO_LIFETIME");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.ClientId)
                .IsUnique();

            builder.ToTable("CLIENTS");
        }
    }
}