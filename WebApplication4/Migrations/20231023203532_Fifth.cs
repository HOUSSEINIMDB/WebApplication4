using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Games_GameId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestNumber",
                table: "Carts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Games_GameId",
                table: "Items",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Games_GameId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TestNumber",
                table: "Carts");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Items",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Games_GameId",
                table: "Items",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId");
        }
    }
}
