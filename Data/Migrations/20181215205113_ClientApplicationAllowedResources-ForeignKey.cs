using Microsoft.EntityFrameworkCore.Migrations;

namespace N17Solutions.Identity.Data.Migrations
{
    public partial class ClientApplicationAllowedResourcesForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                "FK_AllowedResource_OpenIddictApplication",
                "AllowedResource",
                "ClientId",
                "OpenIddictApplication",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_AllowedResource_OpenIddictApplication", "AllowedResource");
        }
    }
}
