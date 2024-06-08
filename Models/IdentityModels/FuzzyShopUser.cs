using Microsoft.AspNetCore.Identity;

namespace PFuzzyArtShop.Models.IdentityModels
{
    public class FuzzyShopUser : IdentityUser
    {

        public string? ShortName { get; set; }


    }
}
