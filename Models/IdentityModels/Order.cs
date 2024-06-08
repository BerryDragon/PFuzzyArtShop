using System;
using System.Collections.Generic;

namespace PFuzzyArtShop.Models.IdentityModels
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; } // Foreign key to FuzzyShopUser
        public decimal TotalCost { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
