using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.Grant.Migrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DEVICE_CODES",
                columns: table => new
                {
                    USER_CODE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DEVICE_CODE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SUBJECT_ID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SESSION_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CLIENT_ID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CREATION_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EXPIRATION = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATA = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEVICE_CODES", x => x.USER_CODE);
                });

            migrationBuilder.CreateTable(
                name: "PERSISTED_GRANTS",
                columns: table => new
                {
                    KEY = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SUBJECT_ID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SESSION_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CLIENT_ID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CREATION_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EXPIRATION = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CONSUMED_TIME = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATA = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSISTED_GRANTS", x => x.KEY);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DEVICE_CODES_DEVICE_CODE",
                table: "DEVICE_CODES",
                column: "DEVICE_CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DEVICE_CODES_EXPIRATION",
                table: "DEVICE_CODES",
                column: "EXPIRATION");

            migrationBuilder.CreateIndex(
                name: "IX_PERSISTED_GRANTS_EXPIRATION",
                table: "PERSISTED_GRANTS",
                column: "EXPIRATION");

            migrationBuilder.CreateIndex(
                name: "IX_PERSISTED_GRANTS_SUBJECT_ID_CLIENT_ID_TYPE",
                table: "PERSISTED_GRANTS",
                columns: new[] { "SUBJECT_ID", "CLIENT_ID", "TYPE" });

            migrationBuilder.CreateIndex(
                name: "IX_PERSISTED_GRANTS_SUBJECT_ID_SESSION_ID_TYPE",
                table: "PERSISTED_GRANTS",
                columns: new[] { "SUBJECT_ID", "SESSION_ID", "TYPE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DEVICE_CODES");

            migrationBuilder.DropTable(
                name: "PERSISTED_GRANTS");
        }
    }
}