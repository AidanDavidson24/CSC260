using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaSite.Migrations
{
    public partial class halfdumb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userName",
                table: "Comments");
        }
    }
}
