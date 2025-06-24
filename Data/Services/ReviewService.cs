using PC_BuyNET.Models.Enums;
using PC_BuyNET.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Identity;
using PC_BuyNET.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace PC_BuyNET.Data.Services
{
    public class ReviewService
    {
        private readonly PC_BuyNETDbContext _context;
        private readonly UserManager<User> _userManager;

        public ReviewService(PC_BuyNETDbContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<bool> AddReviewAsync(string userId, int itemId, int rating, string? comment)
        {
            if (!Review.IsValidRating(rating))
            {
                return false;
            }

            var item = await _context.Items.FindAsync(itemId);
            if (item == null)
            {
                return false;
            }

            string userEmail = await GetUserEmailAsync(userId);

            var review = new Review
            {
                UserId = userId,
                ItemId = itemId,
                Rating = (Rating)rating, 
                Comment = comment,
                UserEmail = userEmail,
                CreatingDate = DateTime.Now
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteReview(int reviewId, string userId)
        {
            if (await RivewBelongsToUser(reviewId, userId))
            {
                var review = await _context.Reviews.FindAsync(reviewId);

                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false; 
            }
        }
        public async Task<bool> RivewBelongsToUser(int reviewId, string userId)
        {
            return await _context.Reviews.AnyAsync(r => r.Id == reviewId &&
            r.UserId == userId);
        }
        private async Task<string> GetUserEmailAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return string.Empty;
            }

            return user?.Email ?? string.Empty;
        }
        public async Task<int> GetReviewIdByUserId(string userId, int itemId)
        {
            var review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.UserId == userId && r.ItemId == itemId);
            return review?.Id ?? 0; // Return 0 if no review found
        }
        public async Task<bool> HasReview(string userId, int itemId)
        {
            return await _context.Reviews.AnyAsync(r => r.UserId == userId &&
                r.ItemId == itemId);
        }
        public async Task<bool> IsUsersReview(string userId, int reviewId)
        {
            return await _context.Reviews.AnyAsync(r => r.UserId == userId &&
                r.Id == reviewId);
        }
        public async Task<Review?> GetReviewByIdAsync(int reviewId, string userId)
        {
            var review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.Id == reviewId &&
                r.UserId == userId);

            return review;
        }
        public async Task<Review?> EditReviewAsync(int reviewId, string userId, int rating, string? comment)
        {
            if (!Review.IsValidRating(rating))
            {
                return null; // Invalid rating
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.Id == reviewId && r.UserId == userId);

            if (review == null)
            {
                return null; // Review not found or user not authorized
            }

            review.Rating = (Rating)rating;
            review.Comment = comment;
            // Do not update CreatingDate; keep original
            // Optionally, add LastModifiedDate if needed:
            // review.LastModifiedDate = DateTime.UtcNow;

            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();

            return review;
        }
    }
}