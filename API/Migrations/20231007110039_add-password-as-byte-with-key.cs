using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class addpasswordasbytewithkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "Imgname",
                table: "Users",
                newName: "ImgName");

            migrationBuilder.DropColumn("Password", "Users");
            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: "test@123");

            migrationBuilder.AddColumn<byte[]>(
                name: "Passwordkey",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Passwordkey",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ImgName",
                table: "Users",
                newName: "Imgname");
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");
        }
    }
}
