using Microsoft.EntityFrameworkCore;
using PC_BuyNET.Models;

namespace PC_BuyNET.Data.Services
{
    public class WishlistService
    {
        private readonly PC_BuyNETDbContext _context;

        public WishlistService(PC_BuyNETDbContext context)
        {
            _context = context;
        }

        public async Task<Wishlist?> GetWishlistByUserIdAsync(string userId)
        {
            return await _context.Wishlists
                .Include(w => w.WishlistItems)
                    .ThenInclude(wi => wi.Item)
                .FirstOrDefaultAsync(w => w.UserId == userId);
        }
        public async Task DeleteFromWishlish(string userId, int WishlistItemId)
        {
            var wishlist = await _context.Wishlists
                .Include(w => w.WishlistItems)
                .FirstOrDefaultAsync(w => w.UserId == userId);

            if (wishlist == null) 
            { 
                return;
            }
            
            var wishlistItem = wishlist.WishlistItems
                .FirstOrDefault(wi => wi.Id == WishlistItemId);
            if (wishlistItem != null)
            {
                wishlist.WishlistItems.Remove(wishlistItem);
                await _context.SaveChangesAsync();
            }
        }
        public async Task AddToWishlistAsync(string userId, int itemId)
        {
            var wishlist = await _context.Wishlists
                .Include(w => w.WishlistItems)
                .FirstOrDefaultAsync(w => w.UserId == userId);

            if (wishlist == null) return;

            bool alreadyExists = wishlist.WishlistItems.Any(wi => wi.ItemId == itemId);
            if (!alreadyExists)
            {
                wishlist.WishlistItems.Add(new WishlistItem
                {
                    ItemId = itemId
                });

                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> IsItemInWishlistAsync(string userId, int itemId)
        {
            if (userId == null)
            {
                return false;
            }
            var wishlist = await _context.Wishlists
                .Include(w => w.WishlistItems)
                .FirstOrDefaultAsync(w => w.UserId == userId);

            if (wishlist == null)
            {
                return false;
            }

            return wishlist.WishlistItems.Any(wi => wi.ItemId == itemId);
        }
    }
}