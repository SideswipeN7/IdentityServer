using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.Configurations.Migrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "API_RESOURCES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENABLED = table.Column<bool>(type: "bit", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DISPLAY_NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ALLOWED_ACCESS_TOKEN_SIGNING_ALGORITHMS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SHOW_IN_DISCOVERY_DOCUMENT = table.Column<bool>(type: "bit", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LAST_ACCESSED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NON_EDITABLE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_RESOURCES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "API_SCOPES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENABLED = table.Column<bool>(type: "bit", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DISPLAY_NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    REQUIRED = table.Column<bool>(type: "bit", nullable: false),
                    EMPHASIZE = table.Column<bool>(type: "bit", nullable: false),
                    SHOW_IN_DISCOVERY_DOCUMENT = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_SCOPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENABLED = table.Column<bool>(type: "bit", nullable: false),
                    CLIENT_ID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PROTOCOL_TYPE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    REQUIRE_CLIENT_SECRET = table.Column<bool>(type: "bit", nullable: false),
                    CLIENT_NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CLIENT_URI = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    LOGO_URI = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    REQUIRE_CONSENT = table.Column<bool>(type: "bit", nullable: false),
                    ALLOW_REMEMBER_CONSENT = table.Column<bool>(type: "bit", nullable: false),
                    ALWAYS_INCLUDE_USER_CLAIMS_IN_ID_TOKEN = table.Column<bool>(type: "bit", nullable: false),
                    REQUIRE_PKCE = table.Column<bool>(type: "bit", nullable: false),
                    ALLOW_PLAIN_TEXT_PKCE = table.Column<bool>(type: "bit", nullable: false),
                    REQUIRE_REQUEST_OBJECT = table.Column<bool>(type: "bit", nullable: false),
                    ALLOW_ACCESS_TOKENS_VIA_BROWSER = table.Column<bool>(type: "bit", nullable: false),
                    FRONT_CHANNEL_LOGOUT_URI = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FRONT_CHANNEL_LOGOUT_SESSION_REQUIRED = table.Column<bool>(type: "bit", nullable: false),
                    BACK_CHANNEL_LOGOUT_URI = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    BACK_CHANNEL_LOGOUT_SESSION_REQUIRED = table.Column<bool>(type: "bit", nullable: false),
                    ALLOW_OFFLINE_ACCESS = table.Column<bool>(type: "bit", nullable: false),
                    IDENTITY_TOKEN_LIFETIME = table.Column<int>(type: "int", nullable: false),
                    ALLOWED_IDENTITY_TOKEN_SIGNING_ALGORITHMS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ACCESS_TOKEN_LIFETIME = table.Column<int>(type: "int", nullable: false),
                    AUTHORIZATION_CODE_LIFETIME = table.Column<int>(type: "int", nullable: false),
                    CONSENT_LIFETIME = table.Column<int>(type: "int", nullable: true),
                    ABSOLUTE_REFRESH_TOKEN_LIFETIME = table.Column<int>(type: "int", nullable: false),
                    SLIDING_REFRESH_TOKEN_LIFETIME = table.Column<int>(type: "int", nullable: false),
                    REFRESH_TOKEN_USAGE = table.Column<int>(type: "int", nullable: false),
                    UPDATE_ACCESS_TOKEN_CLAIMS_ON_REFRESH = table.Column<bool>(type: "bit", nullable: false),
                    REFRESH_TOKEN_EXPIRATION = table.Column<int>(type: "int", nullable: false),
                    AccessTokenType = table.Column<int>(type: "int", nullable: false),
                    ENABLE_LOCAL_LOGIN = table.Column<bool>(type: "bit", nullable: false),
                    INCLUDE_JWT_ID = table.Column<bool>(type: "bit", nullable: false),
                    ALWAYS_SEND_CLIENT_CLAIMS = table.Column<bool>(type: "bit", nullable: false),
                    CLIENT_CLAIMS_PREFIX = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PAIR_WISE_SUBJECT_SALT = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LAST_ACCESSED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_SSO_LIFETIME = table.Column<int>(type: "int", nullable: true),
                    USER_CODE_TYPE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DEVICE_CODE_LIFETIME = table.Column<int>(type: "int", nullable: false),
                    NON_EDITABLE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IDENTITY_RESOURCES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENABLED = table.Column<bool>(type: "bit", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DISPLAY_NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    REQUIRED = table.Column<bool>(type: "bit", nullable: false),
                    EMPHASIZE = table.Column<bool>(type: "bit", nullable: false),
                    SHOW_IN_DISCOVERY_DOCUMENT = table.Column<bool>(type: "bit", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NON_EDITABLE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDENTITY_RESOURCES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "API_RESOURCE_CLAIMS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    API_RESOURCE_ID = table.Column<int>(type: "int", nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_RESOURCE_CLAIMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_API_RESOURCE_CLAIMS_API_RESOURCES_API_RESOURCE_ID",
                        column: x => x.API_RESOURCE_ID,
                        principalTable: "API_RESOURCES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "API_RESOURCE_PROPERTIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    API_RESOURCE_ID = table.Column<int>(type: "int", nullable: false),
                    KEY = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    VALUE = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_RESOURCE_PROPERTIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_API_RESOURCE_PROPERTIES_API_RESOURCES_API_RESOURCE_ID",
                        column: x => x.API_RESOURCE_ID,
                        principalTable: "API_RESOURCES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "API_RESOURCE_SCOPES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SCOPE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    API_RESOURCE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_RESOURCE_SCOPES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_API_RESOURCE_SCOPES_API_RESOURCES_API_RESOURCE_ID",
                        column: x => x.API_RESOURCE_ID,
                        principalTable: "API_RESOURCES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "API_RESOURCE_SECRETS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    API_RESOURCE_ID = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    VALUE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EXPIRATION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TYPE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_RESOURCE_SECRETS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_API_RESOURCE_SECRETS_API_RESOURCES_API_RESOURCE_ID",
                        column: x => x.API_RESOURCE_ID,
                        principalTable: "API_RESOURCES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "API_SCOPE_CLAIMS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SCOPE_ID = table.Column<int>(type: "int", nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_SCOPE_CLAIMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_API_SCOPE_CLAIMS_API_SCOPES_SCOPE_ID",
                        column: x => x.SCOPE_ID,
                        principalTable: "API_SCOPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "API_SCOPE_PROPERTIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SCOPE_ID = table.Column<int>(type: "int", nullable: false),
                    KEY = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    VALUE = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_SCOPE_PROPERTIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_API_SCOPE_PROPERTIES_API_SCOPES_SCOPE_ID",
                        column: x => x.SCOPE_ID,
                        principalTable: "API_SCOPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT_CLAIMS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TYPE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    VALUE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CLIENT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_CLAIMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLIENT_CLAIMS_CLIENTS_CLIENT_ID",
                        column: x => x.CLIENT_ID,
                        principalTable: "CLIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT_CORS_ORIGINS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORIGIN = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CLIENT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_CORS_ORIGINS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLIENT_CORS_ORIGINS_CLIENTS_CLIENT_ID",
                        column: x => x.CLIENT_ID,
                        principalTable: "CLIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT_GRANT_TYPES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GRANT_TYPE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CLIENT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_GRANT_TYPES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLIENT_GRANT_TYPES_CLIENTS_CLIENT_ID",
                        column: x => x.CLIENT_ID,
                        principalTable: "CLIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT_ID_PRESTRICTIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROVIDER = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CLIENT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_ID_PRESTRICTIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLIENT_ID_PRESTRICTIONS_CLIENTS_CLIENT_ID",
                        column: x => x.CLIENT_ID,
                        principalTable: "CLIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT_POST_LOGOUT_REDIRECT_URIS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POST_LOGOUT_REDIRECT_URI = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CLIENT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_POST_LOGOUT_REDIRECT_URIS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLIENT_POST_LOGOUT_REDIRECT_URIS_CLIENTS_CLIENT_ID",
                        column: x => x.CLIENT_ID,
                        principalTable: "CLIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT_PROPERTIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLIENT_ID = table.Column<int>(type: "int", nullable: false),
                    KEY = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    VALUE = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_PROPERTIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLIENT_PROPERTIES_CLIENTS_CLIENT_ID",
                        column: x => x.CLIENT_ID,
                        principalTable: "CLIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT_REDIRECT_URIS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REDIRECT_URI = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CLIENT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_REDIRECT_URIS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLIENT_REDIRECT_URIS_CLIENTS_CLIENT_ID",
                        column: x => x.CLIENT_ID,
                        principalTable: "CLIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT_SCOPES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SCOPE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CLIENT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_SCOPES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLIENT_SCOPES_CLIENTS_CLIENT_ID",
                        column: x => x.CLIENT_ID,
                        principalTable: "CLIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT_SECRETS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLIENT_ID = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    VALUE = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    EXPIRATION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TYPE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_SECRETS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLIENT_SECRETS_CLIENTS_CLIENT_ID",
                        column: x => x.CLIENT_ID,
                        principalTable: "CLIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IDENTITY_RESOURCE_CLAIMS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDENTITY_RESOURCE_ID = table.Column<int>(type: "int", nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDENTITY_RESOURCE_CLAIMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IDENTITY_RESOURCE_CLAIMS_IDENTITY_RESOURCES_IDENTITY_RESOURCE_ID",
                        column: x => x.IDENTITY_RESOURCE_ID,
                        principalTable: "IDENTITY_RESOURCES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IDENTITY_RESOURCE_PROPERTIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDENTITY_RESOURCE_ID = table.Column<int>(type: "int", nullable: false),
                    KEY = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    VALUE = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDENTITY_RESOURCE_PROPERTIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IDENTITY_RESOURCE_PROPERTIES_IDENTITY_RESOURCES_IDENTITY_RESOURCE_ID",
                        column: x => x.IDENTITY_RESOURCE_ID,
                        principalTable: "IDENTITY_RESOURCES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_API_RESOURCE_CLAIMS_API_RESOURCE_ID",
                table: "API_RESOURCE_CLAIMS",
                column: "API_RESOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_API_RESOURCE_PROPERTIES_API_RESOURCE_ID",
                table: "API_RESOURCE_PROPERTIES",
                column: "API_RESOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_API_RESOURCE_SCOPES_API_RESOURCE_ID",
                table: "API_RESOURCE_SCOPES",
                column: "API_RESOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_API_RESOURCE_SECRETS_API_RESOURCE_ID",
                table: "API_RESOURCE_SECRETS",
                column: "API_RESOURCE_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_API_RESOURCES_NAME",
                table: "API_RESOURCES",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_API_SCOPE_CLAIMS_SCOPE_ID",
                table: "API_SCOPE_CLAIMS",
                column: "SCOPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_API_SCOPE_PROPERTIES_SCOPE_ID",
                table: "API_SCOPE_PROPERTIES",
                column: "SCOPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_API_SCOPES_NAME",
                table: "API_SCOPES",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_CLAIMS_CLIENT_ID",
                table: "CLIENT_CLAIMS",
                column: "CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_CORS_ORIGINS_CLIENT_ID",
                table: "CLIENT_CORS_ORIGINS",
                column: "CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_GRANT_TYPES_CLIENT_ID",
                table: "CLIENT_GRANT_TYPES",
                column: "CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_ID_PRESTRICTIONS_CLIENT_ID",
                table: "CLIENT_ID_PRESTRICTIONS",
                column: "CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_POST_LOGOUT_REDIRECT_URIS_CLIENT_ID",
                table: "CLIENT_POST_LOGOUT_REDIRECT_URIS",
                column: "CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_PROPERTIES_CLIENT_ID",
                table: "CLIENT_PROPERTIES",
                column: "CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_REDIRECT_URIS_CLIENT_ID",
                table: "CLIENT_REDIRECT_URIS",
                column: "CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_SCOPES_CLIENT_ID",
                table: "CLIENT_SCOPES",
                column: "CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_SECRETS_CLIENT_ID",
                table: "CLIENT_SECRETS",
                column: "CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTS_CLIENT_ID",
                table: "CLIENTS",
                column: "CLIENT_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IDENTITY_RESOURCE_CLAIMS_IDENTITY_RESOURCE_ID",
                table: "IDENTITY_RESOURCE_CLAIMS",
                column: "IDENTITY_RESOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_IDENTITY_RESOURCE_PROPERTIES_IDENTITY_RESOURCE_ID",
                table: "IDENTITY_RESOURCE_PROPERTIES",
                column: "IDENTITY_RESOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_IDENTITY_RESOURCES_NAME",
                table: "IDENTITY_RESOURCES",
                column: "NAME",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "API_RESOURCE_CLAIMS");

            migrationBuilder.DropTable(
                name: "API_RESOURCE_PROPERTIES");

            migrationBuilder.DropTable(
                name: "API_RESOURCE_SCOPES");

            migrationBuilder.DropTable(
                name: "API_RESOURCE_SECRETS");

            migrationBuilder.DropTable(
                name: "API_SCOPE_CLAIMS");

            migrationBuilder.DropTable(
                name: "API_SCOPE_PROPERTIES");

            migrationBuilder.DropTable(
                name: "CLIENT_CLAIMS");

            migrationBuilder.DropTable(
                name: "CLIENT_CORS_ORIGINS");

            migrationBuilder.DropTable(
                name: "CLIENT_GRANT_TYPES");

            migrationBuilder.DropTable(
                name: "CLIENT_ID_PRESTRICTIONS");

            migrationBuilder.DropTable(
                name: "CLIENT_POST_LOGOUT_REDIRECT_URIS");

            migrationBuilder.DropTable(
                name: "CLIENT_PROPERTIES");

            migrationBuilder.DropTable(
                name: "CLIENT_REDIRECT_URIS");

            migrationBuilder.DropTable(
                name: "CLIENT_SCOPES");

            migrationBuilder.DropTable(
                name: "CLIENT_SECRETS");

            migrationBuilder.DropTable(
                name: "IDENTITY_RESOURCE_CLAIMS");

            migrationBuilder.DropTable(
                name: "IDENTITY_RESOURCE_PROPERTIES");

            migrationBuilder.DropTable(
                name: "API_RESOURCES");

            migrationBuilder.DropTable(
                name: "API_SCOPES");

            migrationBuilder.DropTable(
                name: "CLIENTS");

            migrationBuilder.DropTable(
                name: "IDENTITY_RESOURCES");
        }
    }
}