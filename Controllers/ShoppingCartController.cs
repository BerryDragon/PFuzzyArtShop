using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFuzzyArtShop.Models;
using PFuzzyArtShop.Models.IdentityModels;
using System.Linq;

namespace PFuzzyArtShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly FuzzyContext _context;
        private readonly UserManager<FuzzyShopUser> _userManager;

        public ShoppingCartController(FuzzyContext context, UserManager<FuzzyShopUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var cartItems = _context.ShoppingCartItems
                .Include(item => item.Merch)
                .Where(item => item.UserId == userId)
                .ToList();

            return View(cartItems);
        }

        [HttpPost]
        public IActionResult AddToCart(int merchId)
        {
            var userId = _userManager.GetUserId(User);
            var merch = _context.Merch.FirstOrDefault(m => m.Id == merchId);

            if (merch == null)
            {
                return NotFound();
            }

            var cartItem = _context.ShoppingCartItems.FirstOrDefault(item =>
                item.UserId == userId && item.MerchId == merchId);

            if (cartItem == null)
            {
                cartItem = new ShoppingCartItem
                {
                    UserId = userId,
                    MerchId = merchId,
                    Quantity = 1
                };
                _context.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            _context.SaveChanges();

            TempData["Message"] = $"{merch.Name} has been added to your cart.";

            return RedirectToAction("Index", "Merch");
        }
    }
}