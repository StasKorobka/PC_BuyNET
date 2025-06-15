using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_BuyNET.Areas.Identity.Data;
using PC_BuyNET.Data;
using PC_BuyNET.Models;

namespace PC_BuyNET.Controllers
{
    public class CartController : Controller
    {
        private readonly PC_BuyNETDbContext _context;
        private readonly UserManager<User> _userManager;

        public CartController(PC_BuyNETDbContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var cart = _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Item)
                .FirstOrDefault(c => c.UserId == userId);

            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string cartItemId)
        {
            var userId = _userManager.GetUserId(User);

            var cartItem = await _context.GetCartItemByIdAsync(int.Parse(cartItemId));

            await _context.DeleteCartItemAsync(userId, cartItem);
            
            return RedirectToAction("Index");
        }
    }
}
