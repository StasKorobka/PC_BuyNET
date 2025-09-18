using System.ComponentModel.DataAnnotations;

namespace PC_BuyNET.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "item";

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string? Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        [Range(0, 100_000)]

        public decimal Price { get; set; }

        [Range(0, 100)]
        public int? Discount { get; set; } = 0;

        public string? ImageUrl { get; set; } = "https://cdn.pixabay.com/photo/2016/10/21/20/45/texture-1759179_640.jpg";

        public List<Review> Reviews { get; set; } = new List<Review>();

        public decimal AverageRating
        {
            get
            {
                if (Reviews.Count == 0) return 0;
                return (decimal)Reviews.Average(r => (int)r.Rating);
            }
        }
        public decimal DiscountedPrice
        {
            get
            {
                if (Discount.HasValue && Discount.Value > 0 && Discount.Value <= 100)
                {
                    return Price - (Price * Discount.Value / 100);
                }
                return Price;
            }
        }

        private const int MaxDescriptionLength = 54;

        public static string Truncate(string value, int maxLength=MaxDescriptionLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength) + "...";
        }
        public static string TruncatePrice(decimal price)
        {
            return price.ToString("C2");
        }

        
    }
}