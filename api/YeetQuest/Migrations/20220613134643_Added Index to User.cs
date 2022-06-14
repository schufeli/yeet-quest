using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YeetQuest.Migrations
{
    public partial class AddedIndextoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Index",
                table: "Users",
                column: "Index");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Index",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "Users");
        }
    }
}
