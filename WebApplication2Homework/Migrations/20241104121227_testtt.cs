using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2Homework.Migrations
{
    /// <inheritdoc />
    public partial class testtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBase64",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageBase64",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
