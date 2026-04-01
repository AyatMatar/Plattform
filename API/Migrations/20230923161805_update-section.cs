using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class updatesection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LecturesPerWeek",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Sections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeFrom",
                table: "Sections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeTo",
                table: "Sections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalHoures",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_TeacherId",
                table: "Sections",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Users_TeacherId",
                table: "Sections",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Users_TeacherId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_TeacherId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "LecturesPerWeek",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "TimeFrom",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "TimeTo",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "TotalHoures",
                table: "Sections");
        }
    }
}
