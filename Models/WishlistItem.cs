namespace PC_BuyNET.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }

        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}