using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1._1.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 6, "MicroPhone1", 16.0 },
                    { 2, 7, "MicroPhone2", 95.0 },
                    { 3, 7, "MicroPhone3", 62.0 },
                    { 4, 5, "MicroPhone4", 10.0 },
                    { 5, 4, "MicroPhone5", 70.0 },
                    { 6, 6, "MicroPhone6", 48.0 },
                    { 7, 2, "MicroPhone7", 58.0 },
                    { 8, 5, "MicroPhone8", 33.0 },
                    { 9, 2, "MicroPhone9", 88.0 },
                    { 10, 3, "MicroPhone10", 66.0 },
                    { 11, 1, "MicroPhone11", 45.0 },
                    { 12, 4, "MicroPhone12", 75.0 },
                    { 13, 6, "MicroPhone13", 97.0 },
                    { 14, 4, "MicroPhone14", 93.0 },
                    { 15, 5, "MicroPhone15", 17.0 },
                    { 16, 9, "MicroPhone16", 74.0 },
                    { 17, 3, "MicroPhone17", 88.0 },
                    { 18, 1, "MicroPhone18", 13.0 },
                    { 19, 4, "MicroPhone19", 80.0 },
                    { 20, 6, "MicroPhone20", 87.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
