using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC_BuyNET.Migrations
{
    /// <inheritdoc />
    public partial class ChangedImageUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://my-store.msi.com/cdn/shop/files/Cyborg-15-A13VX-rgb_1_b47f3697-efe5-43d4-b805-03bcbcb38817.png?v=1746417078");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/71LBvbVa95L._AC_UF894,1000_QL80_.jpg");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/61QY3V6A-NL.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: null);
        }
    }
}
