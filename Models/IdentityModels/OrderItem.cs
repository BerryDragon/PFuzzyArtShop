using System;

namespace PFuzzyArtShop.Models.IdentityModels
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; } // Foreign key to Order
        public int MerchId { get; set; } // Foreign key to Merch
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Merch Merch { get; set; } // Navigation property
        public Order Order { get; set; } // Navigation property to Order
    }
}
