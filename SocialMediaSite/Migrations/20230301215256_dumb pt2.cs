using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaSite.Migrations
{
    public partial class dumbpt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "MyPage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userName",
                table: "MyPage");
        }
    }
}
