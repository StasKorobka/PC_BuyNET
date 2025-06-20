using PC_BuyNET.Models.Enums;
using PC_BuyNET.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Identity;
using PC_BuyNET.Areas.Identity.Data;

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
                Rating = (Rating)rating, // Cast to enum if using enum
                Comment = comment,
                UserEmail = userEmail,
                CreatingDate = DateTime.Now
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return true;
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
    }
}
