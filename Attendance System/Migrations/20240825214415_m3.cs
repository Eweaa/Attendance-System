using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attendance_System.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntakeID",
                table: "Intakes");

            migrationBuilder.AddColumn<int>(
                name: "IntakeID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IntakeID",
                table: "Users",
                column: "IntakeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Intakes_IntakeID",
                table: "Users",
                column: "IntakeID",
                principalTable: "Intakes",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Intakes_IntakeID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IntakeID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IntakeID",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "IntakeID",
                table: "Intakes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
