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

        public string? ImageUrl { get; set; } = "https://cdn.pixabay.com/photo/2016/10/21/20/45/texture-1759179_640.jpg";

        
        private const int MaxDescriptionLength = 60;
        public static string Truncate(string value, int maxLength=MaxDescriptionLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength) + "...";
        }
    }
}
