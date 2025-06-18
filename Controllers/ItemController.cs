using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PC_BuyNET.Areas.Identity.Data;
using PC_BuyNET.Data;
using PC_BuyNET.Data.Services;
using PC_BuyNET.Models;

namespace PC_BuyNET.Controllers
{
    public class ItemController : Controller
    {
        private readonly PC_BuyNETDbContext _context;
        private readonly ItemService _itemService;
        private readonly CartService _cartService;
        private readonly CategoryService _categoryService;
        private readonly SearchService _searchService;
        private readonly UserManager<User> _userManager;


        public ItemController(PC_BuyNETDbContext context,
            ItemService itemService,
            CartService cartService,
            CategoryService categoryService,
            SearchService searchService,
            UserManager<User> userManager)
        {
            _context = context;
            _itemService = itemService;
            _cartService = cartService;
            _categoryService = categoryService;
            _searchService = searchService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _itemService.GetItemsAsync();
            var categories = await _categoryService.GetCategoriesAsync();

            ViewBag.Categories = categories;

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
            var items = await _searchService.SearchItemsAsync(searchQuery, category, maxPrice);
            var categories = await _categoryService.GetCategoriesAsync();

            ViewBag.Categories = categories;

            if (items == null || items.Count == 0)
            {
                ViewBag.Message = "No items found.";
            }

            return View("Index", items);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Manage()
        {
            var items = await _itemService.GetItemsAsync();
            return View(items);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Item item)
        {
            
            if (item != null)
            {
                await _itemService.AddItemAsync(item);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name", item.CategoryId);
            return View(item);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name", item.CategoryId);
            return View(item);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Item item)
        {
            await _itemService.UpdateItemAsync(item);

            return RedirectToAction("Manage");
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _itemService.DeleteItemAsync(id);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return NoContent(); // 204
        }
    }
}