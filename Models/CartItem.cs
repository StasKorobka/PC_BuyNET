﻿namespace PC_BuyNET.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int? CartId { get; set; } // Make nullable
        public Cart? Cart { get; set; } // Make nullable
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
        public int Quantity { get; set; } = 1;
        public decimal TotalPrice => Item.Price * Quantity;
    }
}