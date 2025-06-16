using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_BuyNET.Data;
using PC_BuyNET.Areas.Identity.Data;
using PC_BuyNET.Models;
using PC_BuyNET.Data.Services;

namespace PC_BuyNET.Controllers
{
    public class ItemController : Controller
    {
        private readonly PC_BuyNETDbContext _context;
        private readonly ItemService _itemService;
        private readonly CartService _cartService;
        private readonly UserManager<User> _userManager;


        public ItemController(PC_BuyNETDbContext context,
            ItemService itemService,
            CartService cartService,
            UserManager<User> userManager)
        {
            _context = context;
            _itemService = itemService;
            _cartService = cartService;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            var items = await _itemService.GetItemsAsync();
            return View(items);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Buy(int itemId)
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.AddItemToCartAsync(userId, itemId);

            return RedirectToAction("Index");
        }

    }
}
