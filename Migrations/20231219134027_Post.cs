using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelegeramHappyBirthday.Migrations
{
    /// <inheritdoc />
    public partial class Post : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Post",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Post",
                table: "Users");
        }
    }
}
