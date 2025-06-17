using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PC_BuyNET.Areas.Identity.Data;
using PC_BuyNET.Models;

namespace PC_BuyNET.Data
{
    public class PC_BuyNETDbContext : IdentityDbContext<User>
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public PC_BuyNETDbContext(DbContextOptions<PC_BuyNETDbContext> options)
            : base(options) 
        {
            
        }

        // seed data for initial items
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Gaming Laptop",
                    Description = "High-performance laptop for gaming.",
                    Type = "Laptop",
                    Price = 1500.00m,
                    ImageUrl = "https://my-store.msi.com/cdn/shop/files/Cyborg-15-A13VX-rgb_1_b47f3697-efe5-43d4-b805-03bcbcb38817.png?v=1746417078"
                },
                new Item
                {
                    Id = 2,
                    Name = "Mechanical Keyboard",
                    Description = "RGB backlit mechanical keyboard.",
                    Type = "Keyboard",
                    Price = 120.00m,
                    ImageUrl = "https://m.media-amazon.com/images/I/71LBvbVa95L._AC_UF894,1000_QL80_.jpg"
                },
                new Item
                {
                    Id = 3,
                    Name = "Gaming Mouse",
                    Description = "Ergonomic gaming mouse with customizable buttons.",
                    Type = "Mouse",
                    Price = 80.00m,
                    ImageUrl = "https://m.media-amazon.com/images/I/61QY3V6A-NL.jpg"
                },
                new Item
                {
                    Id = 4,
                    Name = "Gaming Monitor",
                    Description = "27-inch 144Hz gaming monitor with G-Sync.",
                    Type = "Monitor",
                    Price = 300.00m,
                    ImageUrl = "https://content.rozetka.com.ua/goods/images/big/404971764.jpg"
                },
                new Item
                {
                    Id = 5,
                    Name = "MSI GeForce RTX4070 12Gb VENTUS 3X E1 OC (RTX 4070 VENTUS 3X E1 12G OC)",
                    Description = "PCI-Express 4.0, 12 ГБ, GDDR6, 192 Bit, Boost - 2505 MHz, 3 x DisplayPort 1.4a, 1 x HDMI 2.1а, 8 pin, 200 W, 308 x 120 x 43 mm",
                    Type = "Graphics card",
                    Price = 800.00m,
                    ImageUrl = "https://content2.rozetka.com.ua/goods/images/big/525946530.jpg"
                },
                new Item
                {
                    Id = 6,
                    Name = "COBRA Advanced (A56.32.S10.46.19908)",
                    Description = "AMD Ryzen 5 5600 (3.5 - 4.4 GHz) / RAM 32 GB / SSD 1 TB / nVidia GeForce RTX 4060, 8 GB / Windows 11 / LAN ",
                    Type = "Gaming PC",
                    Price = 750.00m,
                    ImageUrl = "https://content1.rozetka.com.ua/goods/images/big/555282141.jpg"
                },
                new Item
                {
                    Id = 7,
                    Name = "Gaming Headset",
                    Description = "Comfortable gaming headset with surround sound.",
                    Type = "Headset",
                    Price = 100.00m,
                    ImageUrl = "https://m.media-amazon.com/images/G/01/apparel/rcxgs/tile._CB483369110_.gif"
                }


            );

        }
    }
}
