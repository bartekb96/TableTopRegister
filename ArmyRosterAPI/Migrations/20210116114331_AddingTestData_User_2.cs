using Microsoft.EntityFrameworkCore.Migrations;

namespace ArmyRosterAPI.Migrations
{
    public partial class AddingTestData_User_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rosters_RosterId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RosterId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RosterId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Rosters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rosters_UserId",
                table: "Rosters",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rosters_Users_UserId",
                table: "Rosters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rosters_Users_UserId",
                table: "Rosters");

            migrationBuilder.DropIndex(
                name: "IX_Rosters_UserId",
                table: "Rosters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rosters");

            migrationBuilder.AddColumn<int>(
                name: "RosterId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RosterId",
                table: "Users",
                column: "RosterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rosters_RosterId",
                table: "Users",
                column: "RosterId",
                principalTable: "Rosters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
