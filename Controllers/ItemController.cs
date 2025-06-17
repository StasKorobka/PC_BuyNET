using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PC_BuyNET.Areas.Identity.Data;
using PC_BuyNET.Data;
using PC_BuyNET.Data.Services;

namespace PC_BuyNET.Controllers
{
    public class ItemController : Controller
    {
        private readonly PC_BuyNETDbContext _context;
        private readonly ItemService _itemService;
        private readonly CartService _cartService;
        private readonly SearchService _searchService;
        private readonly UserManager<User> _userManager;


        public ItemController(PC_BuyNETDbContext context,
            ItemService itemService,
            CartService cartService,
            SearchService searchService,
            UserManager<User> userManager)
        {
            _context = context;
            _itemService = itemService;
            _cartService = cartService;
            _searchService = searchService;
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

        public async Task<IActionResult> ViewItem(int itemID)
        {
            var item = await _itemService.GetItemByIdAsync(itemID);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        public async Task<IActionResult> Search(string? searchQuery, string? category, decimal? maxPrice)
        {
            //if (string.IsNullOrEmpty(searchQuery))
            //{
            //    return RedirectToAction("Index");
            //}

            var items = await _searchService.SearchItemsAsync(searchQuery, category, maxPrice);

            if (items == null)
            {
                ViewBag.Message = "No items found.";
            }

            return View("Index", items);
        }
    }
}