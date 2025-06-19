using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PC_BuyNET.Areas.Identity.Data;
using PC_BuyNET.Data.Services;

namespace PC_BuyNET.Controllers
{
    public class OrderController : Controller
    {
        private readonly CartService _cartService;
        private readonly UserManager<User> _userManager;
        private readonly OrderService _orderService;
        public OrderController(CartService cartService,
            OrderService orderService,
            UserManager<User> userManager)
        {
            _cartService = cartService;
            _orderService = orderService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var cartItems = await _cartService.GetCartItemsAsync(userId);

            return View(cartItems);
        }

        [Authorize]
        public async Task<IActionResult> Make()
        {
            var userId = _userManager.GetUserId(User);
            var cartItems = await _cartService.GetCartItemsAsync(userId);

            if (cartItems.Count == 0)
            {
                return RedirectToAction("Index", "Item");
            }

            await _orderService.SaveOrder(userId);

            //Clear the cart.
            await _cartService.ClearCartAsync(userId);

            return RedirectToAction("Index", "Item");
        }

        public async Task<IActionResult> History()
        {
            var userId = _userManager.GetUserId(User);
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);

            return View(orders);
        }
    }
}
