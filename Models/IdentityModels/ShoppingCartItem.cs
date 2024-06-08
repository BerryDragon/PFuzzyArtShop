using PFuzzyArtShop.Models.IdentityModels;

namespace PFuzzyArtShop.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int MerchId { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }

        public Merch Merch { get; set; }
        public FuzzyShopUser User { get; set; }
    }
}