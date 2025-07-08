using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PC_BuyNET.Areas.Identity.Data;
using PC_BuyNET.Data;
using PC_BuyNET.Data.Services;
using PC_BuyNET.Data.Services.Interfaces;
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
        private readonly ReviewService _reviewService;
        private readonly WishlistService _wishlistService;
        private readonly UserManager<User> _userManager;

        private readonly ILoggingService _logger;

        public ItemController(PC_BuyNETDbContext context,
            ItemService itemService,
            CartService cartService,
            CategoryService categoryService,
            SearchService searchService,
            ReviewService reviewService,
            WishlistService wishlistService,
            UserManager<User> userManager,
            ILoggingService logger)
        {
            _context = context;
            _itemService = itemService;
            _cartService = cartService;
            _categoryService = categoryService;
            _searchService = searchService;
            _reviewService = reviewService;
            _wishlistService = wishlistService;
            _userManager = userManager;
            _logger = logger;
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
        public async Task Buy(int itemId)
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.AddItemToCartAsync(userId, itemId);

            _logger.LogInformation($"Item with ID {itemId} added to cart for user {userId}.");
        }
        public async Task<IActionResult> ViewItem(int itemID)
        {
            var item = await _itemService.GetItemByIdAsync(itemID);

            if (item == null)
            {
                _logger.LogError($"Item with ID {itemID} not found.");
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);

            try
            {
                bool isInWishlist = await _wishlistService.IsItemInWishlistAsync(userId, itemID);
                bool userHasReviewes = await _reviewService.HasReview(userId, itemID);
                int reviewId = await _reviewService.GetReviewIdByUserId(userId, itemID);

                ViewBag.IsInWishlist = isInWishlist;
                ViewBag.ReviewId = reviewId;
                ViewBag.UserHasReviewes = userHasReviewes;
            }
            catch
            {
                ViewBag.UserHasReviewes = false;
            }
            
            return View(item);
            
            
        }

        [HttpPost]
        public async Task<IActionResult> Search(string? searchQuery, string? category, decimal? maxPrice, string priceOrder)
        {
            var items = await _searchService.SearchItemsAsync(searchQuery, category, maxPrice, priceOrder);
            var categories = await _categoryService.GetCategoriesAsync();

            ViewBag.Categories = categories;

            
            ViewBag.SelectedCategory = category ?? "All";
            ViewBag.SearchQuery = searchQuery ?? string.Empty;
            ViewBag.MaxPrice = maxPrice ?? 1000;
            ViewBag.PriceOrder = priceOrder ?? "Ascending";

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
                _logger.LogWarning($"Attempted to delete item with ID {id}, but it was not found: {ex.Message}");
                return NotFound(ex.Message);
            }


            return NoContent(); // 204
        }

    }
}