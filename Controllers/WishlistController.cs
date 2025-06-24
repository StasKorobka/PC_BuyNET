using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PC_BuyNET.Areas.Identity.Data;
using PC_BuyNET.Data.Services;

namespace PC_BuyNET.Controllers
{
    public class WishlistController : Controller
    {
        public readonly WishlistService _wishlistService;
        private readonly UserManager<User> _userManager;

        public WishlistController(WishlistService wishlistService,
            UserManager<User> userManager)
        {
            _wishlistService = wishlistService;

            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var wishlist = await _wishlistService.GetWishlistByUserIdAsync(userId);

            return View(wishlist);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int itemId)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            await _wishlistService.AddToWishlistAsync(userId, itemId);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(int wishlistItemId)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            await _wishlistService.DeleteFromWishlish(userId, wishlistItemId);
            return RedirectToAction("Index");
        }
    }
}