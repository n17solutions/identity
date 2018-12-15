using Microsoft.EntityFrameworkCore.Migrations;

namespace N17Solutions.Identity.Data.Migrations
{
    public partial class ClientApplicationAllowedResourcesClientIdIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AllowedResource_ClientId",
                table: "AllowedResource",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AllowedResource_ClientId",
                table: "AllowedResource");
        }
    }
}
