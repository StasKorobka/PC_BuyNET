using System.ComponentModel.DataAnnotations;

namespace PC_BuyNET.Models
{
    public class Item
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "item";
        public string? Description { get; set; }
        
        [Required]
        public string Type { get; set; }

        [Range(0, 100_000)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; } = "https://cdn.pixabay.com/photo/2016/10/21/20/45/texture-1759179_640.jpg";
    }
}
