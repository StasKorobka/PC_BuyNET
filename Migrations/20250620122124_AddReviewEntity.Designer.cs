﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PC_BuyNET.Data;

#nullable disable

namespace PC_BuyNET.Migrations
{
    [DbContext(typeof(PC_BuyNETDbContext))]
    [Migration("20250620122124_AddReviewEntity")]
    partial class AddReviewEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PC_BuyNET.Areas.Identity.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("PC_BuyNET.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("PC_BuyNET.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("PC_BuyNET.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Laptop"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Keyboard"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mouse"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Monitor"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Graphics card"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Gaming PC"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Headset"
                        });
                });

            modelBuilder.Entity("PC_BuyNET.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "High-performance laptop for gaming.",
                            ImageUrl = "https://my-store.msi.com/cdn/shop/files/Cyborg-15-A13VX-rgb_1_b47f3697-efe5-43d4-b805-03bcbcb38817.png?v=1746417078",
                            Name = "Gaming Laptop",
                            Price = 1500.00m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "RGB backlit mechanical keyboard.",
                            ImageUrl = "https://m.media-amazon.com/images/I/71LBvbVa95L._AC_UF894,1000_QL80_.jpg",
                            Name = "Mechanical Keyboard",
                            Price = 120.00m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "Ergonomic gaming mouse with customizable buttons.",
                            ImageUrl = "https://m.media-amazon.com/images/I/61QY3V6A-NL.jpg",
                            Name = "Gaming Mouse",
                            Price = 80.00m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Description = "27-inch 144Hz gaming monitor with G-Sync.",
                            ImageUrl = "https://content.rozetka.com.ua/goods/images/big/404971764.jpg",
                            Name = "Gaming Monitor",
                            Price = 300.00m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            Description = "PCI-Express 4.0, 12 ГБ, GDDR6, 192 Bit, Boost - 2505 MHz, 3 x DisplayPort 1.4a, 1 x HDMI 2.1а, 8 pin, 200 W, 308 x 120 x 43 mm",
                            ImageUrl = "https://content2.rozetka.com.ua/goods/images/big/525946530.jpg",
                            Name = "MSI GeForce RTX4070 12Gb VENTUS 3X E1 ",
                            Price = 800.00m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 6,
                            Description = "AMD Ryzen 5 5600 (3.5 - 4.4 GHz) / RAM 32 GB / SSD 1 TB / nVidia GeForce RTX 4060, 8 GB / Windows 11 / LAN ",
                            ImageUrl = "https://content1.rozetka.com.ua/goods/images/big/555282141.jpg",
                            Name = "COBRA Advanced (A56.32.S10.46.19908)",
                            Price = 750.00m
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 7,
                            Description = "Comfortable gaming headset with surround sound.",
                            ImageUrl = "https://cdn.27.ua/799/b0/83/7843971_16.jpeg",
                            Name = "Gaming Headset",
                            Price = 100.00m
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Description = "Low-profile mechanical gaming keyboard with customizable RGB lighting.",
                            ImageUrl = "https://images.prom.ua/5754698902_w600_h600_5754698902.jpg",
                            Name = "Razer Ornata V3 X Gaming Keyboard",
                            Price = 30.00m
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 4,
                            Description = "24.5-inch Broadened Display – Enjoy the upgraded canvas in the limited space.",
                            ImageUrl = "https://asset.msi.com/resize/image/global/product/product_1724207954ab05b1ca8782cf0f7ef39ef6ca9a7d56.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png",
                            Name = "MSI PRO 24.5-inch IPS (FHD) Gaming Office Monitor",
                            Price = 97.50m
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 1,
                            Description = "Intel Celeron N4120, 4 GB RAM, 64 GB eMMC, 14\" HD Display, Chrome OS, Thin Design, 4K Graphics, Long Battery Life, Ash Gray Keyboard",
                            ImageUrl = "https://hp.widen.net/content/j3evgos0b0/png/j3evgos0b0.png?w=800&h=600&dpi=72&color=ffffff00",
                            Name = "HP Chromebook 14 Laptop",
                            Price = 140.00m
                        });
                });

            modelBuilder.Entity("PC_BuyNET.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PC_BuyNET.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PC_BuyNET.Areas.Identity.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PC_BuyNET.Areas.Identity.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_BuyNET.Areas.Identity.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PC_BuyNET.Areas.Identity.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_BuyNET.Models.Cart", b =>
                {
                    b.HasOne("PC_BuyNET.Areas.Identity.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PC_BuyNET.Models.CartItem", b =>
                {
                    b.HasOne("PC_BuyNET.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId");

                    b.HasOne("PC_BuyNET.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_BuyNET.Models.Order", null)
                        .WithMany("CartItems")
                        .HasForeignKey("OrderId");

                    b.Navigation("Cart");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("PC_BuyNET.Models.Item", b =>
                {
                    b.HasOne("PC_BuyNET.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PC_BuyNET.Models.Review", b =>
                {
                    b.HasOne("PC_BuyNET.Models.Item", "Item")
                        .WithMany("Reviews")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("PC_BuyNET.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("PC_BuyNET.Models.Item", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("PC_BuyNET.Models.Order", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
