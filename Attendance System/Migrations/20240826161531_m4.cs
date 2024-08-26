using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attendance_System.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intakes_Programs_ProgramID",
                table: "Intakes");

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProgramID",
                table: "Intakes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Intakes_Programs_ProgramID",
                table: "Intakes",
                column: "ProgramID",
                principalTable: "Programs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intakes_Programs_ProgramID",
                table: "Intakes");

            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "ProgramID",
                table: "Intakes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Intakes_Programs_ProgramID",
                table: "Intakes",
                column: "ProgramID",
                principalTable: "Programs",
                principalColumn: "ID");
        }
    }
}
