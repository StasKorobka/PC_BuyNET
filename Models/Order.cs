using System.ComponentModel.DataAnnotations;

namespace PC_BuyNET.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required]
        public string UserId { get; set; }

        public List<CartItem> CartItems { get; set; } = new();

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now ;
    }
}