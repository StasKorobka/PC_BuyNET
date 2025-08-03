using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PC_BuyNET.Areas.Identity.Data;
using PC_BuyNET.Data;
using PC_BuyNET.Data.Services;
using PC_BuyNET.Data.Services.Interfaces;

namespace PC_BuyNET.Controllers
{
    public class CartController : Controller
    {
        private readonly PC_BuyNETDbContext _context;
        private readonly CartService _cartService;
        private readonly UserManager<User> _userManager;
        private readonly ILoggingService _logger;
        public CartController(PC_BuyNETDbContext context,
            CartService cartService,
            UserManager<User> userManager,
            ILoggingService logger)
        {
            _context = context;
            _cartService = cartService;
            _userManager = userManager;
            _logger = logger;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var cart = await _cartService.GetCartByUserIdAsync(userId);
            
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Delete(int cartItemId)
        {
            var userId = _userManager.GetUserId(User);

            var cartItem = await _cartService.GetCartItemByIdAsync(cartItemId);

            await _cartService.DeleteCartItemAsync(userId, cartItem);

            _logger.LogInformation($"Cleared cart item with ID {cartItemId} for user {userId}.\nOrderComplete");
            return RedirectToAction("Index");
        }
    }
}
