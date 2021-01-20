using Microsoft.EntityFrameworkCore.Migrations;

namespace ArmyRosterAPI.Migrations
{
    public partial class AddingTestData_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems");

            migrationBuilder.RenameTable(
                name: "TodoItems",
                newName: "Rosters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rosters",
                table: "Rosters",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Rosters",
                columns: new[] { "Id", "ArmyName", "User" },
                values: new object[] { 1, "Strongers Army Ever", "Bartosz" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rosters",
                table: "Rosters");

            migrationBuilder.DeleteData(
                table: "Rosters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Rosters",
                newName: "TodoItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems",
                column: "Id");
        }
    }
}
