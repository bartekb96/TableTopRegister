using Microsoft.EntityFrameworkCore.Migrations;

namespace ArmyRosterAPI.Migrations
{
    public partial class AddingTestData_User_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rosters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "User",
                table: "Rosters");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RosterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Rosters_RosterId",
                        column: x => x.RosterId,
                        principalTable: "Rosters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RosterId",
                table: "Users",
                column: "RosterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Rosters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Rosters",
                columns: new[] { "Id", "ArmyName", "User" },
                values: new object[] { 1, "Strongers Army Ever", "Bartosz" });
        }
    }
}
