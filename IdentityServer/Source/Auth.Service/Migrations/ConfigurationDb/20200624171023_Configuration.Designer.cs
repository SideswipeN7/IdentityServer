﻿// <auto-generated />
using System;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Auth.Service.Migrations.ConfigurationDb
{
    [DbContext(typeof(ConfigurationDbContext))]
    [Migration("20200624171023_Configuration")]
    partial class Configuration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AllowedAccessTokenSigningAlgorithms")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastAccessed")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<bool>("NonEditable")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ShowInDiscoveryDocument")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ApiResources");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApiResourceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ApiResourceId");

                    b.ToTable("ApiResourceClaims");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApiResourceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.HasIndex("ApiResourceId");

                    b.ToTable("ApiResourceProperties");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceScope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApiResourceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ApiResourceId");

                    b.ToTable("ApiResourceScopes");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceSecret", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApiResourceId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.HasIndex("ApiResourceId");

                    b.ToTable("ApiResourceSecrets");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<bool>("Emphasize")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<bool>("Required")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ShowInDiscoveryDocument")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ApiScopes");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScopeClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ScopeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ScopeId");

                    b.ToTable("ApiScopeClaims");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScopeProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.Property<int>("ScopeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.HasIndex("ScopeId");

                    b.ToTable("ApiScopeProperties");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AbsoluteRefreshTokenLifetime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessTokenLifetime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessTokenType")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllowAccessTokensViaBrowser")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllowOfflineAccess")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllowPlainTextPkce")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllowRememberConsent")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AllowedIdentityTokenSigningAlgorithms")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<bool>("AlwaysIncludeUserClaimsInIdToken")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AlwaysSendClientClaims")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorizationCodeLifetime")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BackChannelLogoutSessionRequired")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BackChannelLogoutUri")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.Property<string>("ClientClaimsPrefix")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("ClientName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("ClientUri")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.Property<int?>("ConsentLifetime")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.Property<int>("DeviceCodeLifetime")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EnableLocalLogin")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("FrontChannelLogoutSessionRequired")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FrontChannelLogoutUri")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.Property<int>("IdentityTokenLifetime")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IncludeJwtId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastAccessed")
                        .HasColumnType("TEXT");

                    b.Property<string>("LogoUri")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.Property<bool>("NonEditable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PairWiseSubjectSalt")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("ProtocolType")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<int>("RefreshTokenExpiration")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RefreshTokenUsage")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RequireClientSecret")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RequireConsent")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RequirePkce")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RequireRequestObject")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SlidingRefreshTokenLifetime")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("UpdateAccessTokenClaimsOnRefresh")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserCodeType")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<int?>("UserSsoLifetime")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientClaims");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientCorsOrigin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientCorsOrigins");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientGrantType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GrantType")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientGrantTypes");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientIdPRestriction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientIdPRestrictions");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientPostLogoutRedirectUri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostLogoutRedirectUri")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientPostLogoutRedirectUris");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientProperties");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientRedirectUri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RedirectUri")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientRedirectUris");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientScope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientScopes");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientSecret", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientSecrets");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<bool>("Emphasize")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<bool>("NonEditable")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Required")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ShowInDiscoveryDocument")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("IdentityResources");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityResourceClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdentityResourceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("IdentityResourceId");

                    b.ToTable("IdentityResourceClaims");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityResourceProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdentityResourceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.HasIndex("IdentityResourceId");

                    b.ToTable("IdentityResourceProperties");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceClaim", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ApiResource", "ApiResource")
                        .WithMany("UserClaims")
                        .HasForeignKey("ApiResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceProperty", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ApiResource", "ApiResource")
                        .WithMany("Properties")
                        .HasForeignKey("ApiResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceScope", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ApiResource", "ApiResource")
                        .WithMany("Scopes")
                        .HasForeignKey("ApiResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceSecret", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ApiResource", "ApiResource")
                        .WithMany("Secrets")
                        .HasForeignKey("ApiResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScopeClaim", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ApiScope", "Scope")
                        .WithMany("UserClaims")
                        .HasForeignKey("ScopeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScopeProperty", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ApiScope", "Scope")
                        .WithMany("Properties")
                        .HasForeignKey("ScopeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientClaim", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("Claims")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientCorsOrigin", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("AllowedCorsOrigins")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientGrantType", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("AllowedGrantTypes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientIdPRestriction", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("IdentityProviderRestrictions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientPostLogoutRedirectUri", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("PostLogoutRedirectUris")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientProperty", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("Properties")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientRedirectUri", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("RedirectUris")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientScope", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("AllowedScopes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientSecret", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("ClientSecrets")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityResourceClaim", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.IdentityResource", "IdentityResource")
                        .WithMany("UserClaims")
                        .HasForeignKey("IdentityResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityResourceProperty", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.IdentityResource", "IdentityResource")
                        .WithMany("Properties")
                        .HasForeignKey("IdentityResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
