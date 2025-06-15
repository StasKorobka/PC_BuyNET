using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_BuyNET.Data;
using PC_BuyNET.Areas.Identity.Data;
using PC_BuyNET.Models;

namespace PC_BuyNET.Controllers
{
    public class ItemController : Controller
    {
        private readonly PC_BuyNETDbContext _context;
        private readonly UserManager<User> _userManager;


        public ItemController(PC_BuyNETDbContext context, 
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            var items = await _context.GetItemsAsync();
            return View(items);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Buy(int itemId)
        {
            var userId = _userManager.GetUserId(User);
            //var cart = await _context.Carts
            //    .Include(c => c.CartItems)
            //    .FirstOrDefaultAsync(c => c.UserId == userId);

            //if (cart == null) return NotFound();

            //var item = await _context.GetItemByIdAsync(id);
            //if (item == null) return NotFound();

            //CartItem cartItem = new CartItem{
            //    CartId = cart.Id,
            //    ItemId = item.Id,

            //};

            //cart.CartItems!.Add(cartItem);
            //await _context.SaveChangesAsync();
            await _context.AddItemToCartAsync(userId, itemId);


            return RedirectToAction("Index");
        }

    }
}
