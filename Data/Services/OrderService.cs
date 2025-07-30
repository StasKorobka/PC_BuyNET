using Microsoft.EntityFrameworkCore;
using PC_BuyNET.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PC_BuyNET.Data.Services
{
    public class OrderService
    {
        private readonly PC_BuyNETDbContext _context;

        public OrderService(PC_BuyNETDbContext context)
        {
            _context = context;
        }

        public async Task SaveOrder(string userId)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Item)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            var cartItems = cart.CartItems; 

            if (cart != null && cartItems.Count > 0)
            {
                var order = new Order
                {
                    UserId = userId,
                    OrderDate = DateTime.Now,
                    CartItems = new List<CartItem>()
                };

                //create new cart items for the order
                foreach (var cartItem in cart.CartItems)
                {
                    var newCartItem = new CartItem
                    {
                        ItemId = cartItem.ItemId,
                        Item = cartItem.Item,
                        Quantity = cartItem.Quantity,
                        
                    };

                    order.CartItems.Add(newCartItem);
                }

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _context.Orders
                .Include(o => o.CartItems)
                .ThenInclude(ci => ci.Item)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
    }
}
