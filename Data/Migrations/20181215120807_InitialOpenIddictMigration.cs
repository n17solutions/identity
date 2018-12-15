using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace N17Solutions.Identity.Data.Migrations
{
    public partial class InitialOpenIddictMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OpenIddictApplication",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ClientId = table.Column<string>(maxLength: 100, nullable: false),
                    ClientSecret = table.Column<string>(nullable: true),
                    ConcurrencyToken = table.Column<string>(maxLength: 50, nullable: true),
                    ConsentType = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Permissions = table.Column<string>(nullable: true),
                    PostLogoutRedirectUris = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true),
                    RedirectUris = table.Column<string>(nullable: true),
                    Type = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictApplication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictScope",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyToken = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Properties = table.Column<string>(nullable: true),
                    Resources = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictScope", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictAuthorization",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ApplicationId = table.Column<string>(nullable: true),
                    ConcurrencyToken = table.Column<string>(maxLength: 50, nullable: true),
                    Properties = table.Column<string>(nullable: true),
                    Scopes = table.Column<string>(nullable: true),
                    Status = table.Column<string>(maxLength: 25, nullable: false),
                    Subject = table.Column<string>(maxLength: 450, nullable: false),
                    Type = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictAuthorization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictAuthorization_OpenIddictApplication_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictToken",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ApplicationId = table.Column<string>(nullable: true),
                    AuthorizationId = table.Column<string>(nullable: true),
                    ConcurrencyToken = table.Column<string>(maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(nullable: true),
                    ExpirationDate = table.Column<DateTimeOffset>(nullable: true),
                    Payload = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true),
                    ReferenceId = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 25, nullable: false),
                    Subject = table.Column<string>(maxLength: 450, nullable: false),
                    Type = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictToken_OpenIddictApplication_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenIddictToken_OpenIddictAuthorization_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "OpenIddictAuthorization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictApplication_ClientId",
                table: "OpenIddictApplication",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictAuthorization_ApplicationId_Status_Subject_Type",
                table: "OpenIddictAuthorization",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictScope_Name",
                table: "OpenIddictScope",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictToken_AuthorizationId",
                table: "OpenIddictToken",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictToken_ReferenceId",
                table: "OpenIddictToken",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictToken_ApplicationId_Status_Subject_Type",
                table: "OpenIddictToken",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpenIddictScope");

            migrationBuilder.DropTable(
                name: "OpenIddictToken");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorization");

            migrationBuilder.DropTable(
                name: "OpenIddictApplication");
        }
    }
}
