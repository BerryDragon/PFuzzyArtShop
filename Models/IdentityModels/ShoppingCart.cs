namespace PFuzzyArtShop.Models.IdentityModels
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string CustomerId { get; set; } // Foreign key to FuzzyShopUser
        public ICollection<ShoppingCartItem> Items { get; set; }
    }
}
