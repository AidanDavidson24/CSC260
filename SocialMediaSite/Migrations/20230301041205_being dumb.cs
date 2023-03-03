using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaSite.Migrations
{
    public partial class beingdumb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Comments",
                newName: "userName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Comments",
                newName: "userID");
        }
    }
}
