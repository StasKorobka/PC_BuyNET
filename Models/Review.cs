using PC_BuyNET.Models.Enums;

namespace PC_BuyNET.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; } 

        public Rating Rating { get; set; } // 1 to 5 stars

        public string? Comment { get; set; } = string.Empty;

        public DateTime CreatingDate { get; set; } = DateTime.UtcNow;

        public static bool IsValidRating(int rating)
        {
            return rating >= 1 && rating <= 5;
        }
    }
}
