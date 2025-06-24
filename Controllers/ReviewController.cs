using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_BuyNET.Areas.Identity.Data;
using PC_BuyNET.Data.Services;

namespace PC_BuyNET.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewService _reviewService;
        private readonly UserManager<User> _userManager;

        public ReviewController(ReviewService reviewService,
            UserManager<User> userManager)
        {
            _reviewService = reviewService;

            _userManager = userManager;
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(int reviewId)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                var success = await _reviewService.DeleteReview(reviewId, userId);
                if (success)
                {
                    return Json(new { success = true, message = "Review deleted successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Review not found or you are not authorized to delete it." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return Json(new { success = false, message = "An error occurred while deleting the review." });
            }
        }

        [Authorize]
        public async Task<IActionResult> Edit(int reviewId, int itemId, int rating, string? comment)
        {
            string userId = _userManager.GetUserId(User);

            if (!ModelState.IsValid)
            {
                var review = await _reviewService.GetReviewByIdAsync(reviewId, userId);
                if (review == null)
                {
                    return NotFound();
                }
                return View(review); // Re-render form with validation errors
            }

            var updatedReview = await _reviewService.EditReviewAsync(reviewId, userId, rating, comment);
            if (updatedReview == null)
            {
                ModelState.AddModelError("", "Invalid rating, review not found, or you are not authorized to edit this review.");
                var review = await _reviewService.GetReviewByIdAsync(reviewId, userId);
                if (review == null)
                {
                    return NotFound();
                }
                return View(review);
            }

            return RedirectToAction("ViewItem", "Item", new { itemId = itemId });
        }
    }
}