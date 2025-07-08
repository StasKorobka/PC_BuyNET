using Microsoft.EntityFrameworkCore;
using PC_BuyNET.Data.Services.Interfaces;
using PC_BuyNET.Models;

namespace PC_BuyNET.Data.Services
{
    public class CartService
    {
        private readonly PC_BuyNETDbContext _context;
        private readonly ItemService _itemService;
        private readonly ILoggingService _logger;

        public CartService(PC_BuyNETDbContext context,
            ItemService itemService,
            ILoggingService logger)
        {
            _context = context;
            _itemService = itemService;
            _logger = logger;
        }
        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Item)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }
        public async Task<CartItem> GetCartItemByIdAsync(int cartItemId)
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Item)
                .SelectMany(c => c.CartItems)
                .FirstOrDefaultAsync(ci => ci.Id == cartItemId);
        }
        public async Task<List<CartItem>> GetCartItemsAsync(string userId)
        {
            var cart = await GetCartByUserIdAsync(userId);

            return cart?.CartItems ?? new List<CartItem>();
        }
        public async Task DeleteCartItemAsync(string userId, CartItem cartitem)
        {
            var cart = await GetCartByUserIdAsync(userId);

            if (cart != null)
            {
                if (cartitem.Quantity > 1)
                {
                    cartitem.Quantity--;
                    _logger.LogInformation($"Decreased quantity of item {cartitem.ItemId} in cart for user {userId}. New quantity: {cartitem.Quantity}");
                }
                else
                {
                    cart.CartItems.Remove(cartitem);
                    _logger.LogInformation($"Removed item {cartitem.ItemId} from cart for user {userId}.");
                }

                await _context.SaveChangesAsync();
            }
        }
        public async Task ClearCartAsync(string userId)
        {
            var cart = await GetCartByUserIdAsync(userId);
            if (cart != null)
            {
                cart.CartItems.Clear();
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Cleared cart for user {userId}.");
            }
        }
        public async Task AddItemToCartAsync(string userId, int itemId)
        {
            var cart = await GetCartByUserIdAsync(userId);
            var item = await _itemService.GetItemByIdAsync(itemId);


            if (await IsItemInCartAsync(userId, itemId))
            {
                var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ItemId == itemId);
                cartItem.Quantity++;

                _logger.LogInformation($"Increased quantity of item {itemId} in cart for user {userId}.\n New quantity: {cartItem.Quantity}");
            }
            else
            {
                var cartItem = new CartItem
                {
                    ItemId = itemId,
                    Item = item,
                    CartId = cart.Id,
                    Cart = cart,
                };

                cart.CartItems.Add(cartItem);
                _logger.LogInformation($"Added item {itemId} to cart for user {userId}.");
            }

            await _context.SaveChangesAsync();
        }
        public async Task<bool> IsItemInCartAsync(string userId, int itemId)
        {
            var cart = await GetCartByUserIdAsync(userId);

            if (cart != null)
            {
                return cart.CartItems.Any(ci => ci.ItemId == itemId);
            }

            return false;
        }
    }
}