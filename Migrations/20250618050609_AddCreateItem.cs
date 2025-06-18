using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PC_BuyNET.Migrations
{
    /// <inheritdoc />
    public partial class AddCreateItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "MSI GeForce RTX4070 12Gb VENTUS 3X E1 ");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://cdn.27.ua/799/b0/83/7843971_16.jpeg");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 8, 2, "Low-profile mechanical gaming keyboard with customizable RGB lighting.", "https://images.prom.ua/5754698902_w600_h600_5754698902.jpg", "Razer Ornata V3 X Gaming Keyboard", 30.00m },
                    { 9, 4, "24.5-inch Broadened Display – Enjoy the upgraded canvas in the limited space.", "https://asset.msi.com/resize/image/global/product/product_1724207954ab05b1ca8782cf0f7ef39ef6ca9a7d56.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png", "MSI PRO 24.5-inch IPS 1920 x 1080 (FHD) Gaming Office Monitor", 97.50m },
                    { 10, 1, "Intel Celeron N4120, 4 GB RAM, 64 GB eMMC, 14\" HD Display, Chrome OS, Thin Design, 4K Graphics, Long Battery Life, Ash Gray Keyboard", "https://hp.widen.net/content/j3evgos0b0/png/j3evgos0b0.png?w=800&h=600&dpi=72&color=ffffff00", "HP Chromebook 14 Laptop", 140.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "MSI GeForce RTX4070 12Gb VENTUS 3X E1 OC (RTX 4070 VENTUS 3X E1 12G OC)");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/G/01/apparel/rcxgs/tile._CB483369110_.gif");
        }
    }
}
