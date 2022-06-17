using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YeetQuest.Migrations
{
    public partial class AuthorNametomessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Messages");
        }
    }
}
