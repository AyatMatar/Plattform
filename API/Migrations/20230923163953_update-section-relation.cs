using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class updatesectionrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Users_TeacherId",
                table: "Sections");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Users_TeacherId",
                table: "Sections",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Users_TeacherId",
                table: "Sections");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Sections",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Users_TeacherId",
                table: "Sections",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
