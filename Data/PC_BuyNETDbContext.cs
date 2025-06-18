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
        public DbSet<Category> Categories { get; set; }

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
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Laptop"
                },
                new Category
                {
                    Id = 2,
                    Name = "Keyboard"
                },
                new Category
                {
                    Id = 3,
                    Name = "Mouse"
                },
                new Category
                {
                    Id = 4,
                    Name = "Monitor"
                },
                new Category
                {
                    Id = 5,
                    Name = "Graphics card"
                },
                new Category
                {
                    Id = 6,
                    Name = "Gaming PC"
                },
                new Category
                {
                    Id = 7,
                    Name = "Headset"
                }
                );
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Gaming Laptop",
                    Description = "High-performance laptop for gaming.",
                    CategoryId = 1,
                    Price = 1500.00m,
                    ImageUrl = "https://my-store.msi.com/cdn/shop/files/Cyborg-15-A13VX-rgb_1_b47f3697-efe5-43d4-b805-03bcbcb38817.png?v=1746417078"
                },
                new Item
                {
                    Id = 2,
                    Name = "Mechanical Keyboard",
                    Description = "RGB backlit mechanical keyboard.",
                    CategoryId = 2,
                    Price = 120.00m,
                    ImageUrl = "https://m.media-amazon.com/images/I/71LBvbVa95L._AC_UF894,1000_QL80_.jpg"
                },
                new Item
                {
                    Id = 3,
                    Name = "Gaming Mouse",
                    Description = "Ergonomic gaming mouse with customizable buttons.",
                    CategoryId = 3,
                    Price = 80.00m,
                    ImageUrl = "https://m.media-amazon.com/images/I/61QY3V6A-NL.jpg"
                },
                new Item
                {
                    Id = 4,
                    Name = "Gaming Monitor",
                    Description = "27-inch 144Hz gaming monitor with G-Sync.",
                    CategoryId = 4,
                    Price = 300.00m,
                    ImageUrl = "https://content.rozetka.com.ua/goods/images/big/404971764.jpg"
                },
                new Item
                {
                    Id = 5,
                    Name = "MSI GeForce RTX4070 12Gb VENTUS 3X E1 ",
                    Description = "PCI-Express 4.0, 12 ГБ, GDDR6, 192 Bit, Boost - 2505 MHz, 3 x DisplayPort 1.4a, 1 x HDMI 2.1а, 8 pin, 200 W, 308 x 120 x 43 mm",
                    CategoryId = 5,
                    Price = 800.00m,
                    ImageUrl = "https://content2.rozetka.com.ua/goods/images/big/525946530.jpg"
                },
                new Item
                {
                    Id = 6,
                    Name = "COBRA Advanced (A56.32.S10.46.19908)",
                    Description = "AMD Ryzen 5 5600 (3.5 - 4.4 GHz) / RAM 32 GB / SSD 1 TB / nVidia GeForce RTX 4060, 8 GB / Windows 11 / LAN ",
                    CategoryId = 6,
                    Price = 750.00m,
                    ImageUrl = "https://content1.rozetka.com.ua/goods/images/big/555282141.jpg"
                },
                new Item
                {
                    Id = 7,
                    Name = "Gaming Headset",
                    Description = "Comfortable gaming headset with surround sound.",
                    CategoryId = 7,
                    Price = 100.00m,
                    ImageUrl = "https://cdn.27.ua/799/b0/83/7843971_16.jpeg"
                },
                new Item
                {
                    Id = 8,
                    Name = "Razer Ornata V3 X Gaming Keyboard",
                    Description = "Low-profile mechanical gaming keyboard with customizable RGB lighting.",
                    CategoryId = 2,
                    Price = 30.00m,
                    ImageUrl = "https://images.prom.ua/5754698902_w600_h600_5754698902.jpg"
                },
                new Item
                {
                    Id = 9,
                    Name = "MSI PRO 24.5-inch IPS 1920 x 1080 (FHD) Gaming Office Monitor",
                    Description = "24.5-inch Broadened Display – Enjoy the upgraded canvas in the limited space.",
                    CategoryId = 4,
                    Price = 97.50m,
                    ImageUrl = "https://asset.msi.com/resize/image/global/product/product_1724207954ab05b1ca8782cf0f7ef39ef6ca9a7d56.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png"
                },
                new Item
                {
                    Id = 10,
                    Name = "HP Chromebook 14 Laptop",
                    Description = "Intel Celeron N4120, 4 GB RAM, 64 GB eMMC, 14\" HD Display, Chrome OS, Thin Design, 4K Graphics, Long Battery Life, Ash Gray Keyboard",
                    CategoryId = 1,
                    Price = 140.00m,
                    ImageUrl = "https://hp.widen.net/content/j3evgos0b0/png/j3evgos0b0.png?w=800&h=600&dpi=72&color=ffffff00"
                }


            );

        }
    }
}