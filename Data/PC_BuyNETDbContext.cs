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

        //ITEMS
        //public async Task<List<Item>> GetItemsAsync()
        //{
        //    return await Items.ToListAsync();
        //}

        //public async Task<Item> GetItemByIdAsync(int id)
        //{
        //    return await Items.FindAsync(id);
        //}

        //public async Task AddItemAsync(Item item)
        //{
        //    Items.Add(item);
        //    await SaveChangesAsync();
        //}

        //public async Task UpdateItemAsync(Item item)
        //{
        //    Items.Update(item);
        //    await SaveChangesAsync();
        //}

        //public async Task DeleteItemAsync(int id)
        //{
        //    var item = await GetItemByIdAsync(id);
        //    if (item != null)
        //    {
        //        Items.Remove(item);
        //        await SaveChangesAsync();
        //    }
        //}

        //CART

        //public async Task<Cart> GetCartByUserIdAsync(string userId)
        //{
        //    return await Carts
        //        .Include(c => c.CartItems)
        //        .ThenInclude(ci => ci.Item)
        //        .FirstOrDefaultAsync(c => c.UserId == userId);
        //}

        //public async Task<CartItem> GetCartItemByIdAsync(int cartItemId)
        //{
        //    return await Carts
        //        .Include(c => c.CartItems)
        //        .ThenInclude(ci => ci.Item)
        //        .SelectMany(c => c.CartItems)
        //        .FirstOrDefaultAsync(ci => ci.Id == cartItemId);
        //}

        //public async Task DeleteCartItemAsync(string userId, CartItem cartitem)
        //{
        //    var cart = await GetCartByUserIdAsync(userId);

        //    if (cart != null)
        //    {
        //        if (cartitem.Quantity > 1)
        //        {
        //            cartitem.Quantity--;
        //        }
        //        else
        //        {
        //            cart.CartItems.Remove(cartitem);
        //        }
                    
        //        await SaveChangesAsync();
        //    }
        //}

        //public async Task AddItemToCartAsync(string userId, int itemId)
        //{
        //    var cart = await GetCartByUserIdAsync(userId);
        //    var item = await GetItemByIdAsync(itemId);

            
        //    if (IsItemInCart(userId, itemId))
        //    {
        //        var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ItemId == itemId);
        //        cartItem.Quantity++;
        //    }
        //    else
        //    {
        //        var cartItem = new CartItem 
        //        { 
        //            ItemId = itemId,
        //            Item = item,
        //            CartId = cart.Id,
        //            Cart = cart,
        //        };
                
        //        cart.CartItems.Add(cartItem);
        //    }

        //    await SaveChangesAsync();
        //}

        //public bool IsItemInCart(string userId, int itemId)
        //{
        //    var cart = GetCartByUserIdAsync(userId).Result;

        //    if (cart != null)
        //    {
        //        return cart.CartItems.Any(ci => ci.ItemId == itemId);
        //    }

        //    return false;
        //}
        
        
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
                }

            );

        }
    }
}
