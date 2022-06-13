using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YeetQuest.Migrations
{
    public partial class AddedIndextoChannel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Chats",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_Index",
                table: "Chats",
                column: "Index");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chats_Index",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "Chats");
        }
    }
}
