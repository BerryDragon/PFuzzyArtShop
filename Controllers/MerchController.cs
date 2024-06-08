using Microsoft.AspNetCore.Mvc;
using PFuzzyArtShop.Models;

namespace PFuzzyArtShop.Controllers
{
    public class MerchController : Controller
    {
        private readonly FuzzyContext _context;

        public MerchController(FuzzyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var merchandise = _context.Merch.ToList();
            return View(merchandise);
        }

        public IActionResult Details(int id)
        {
            var merch = _context.Merch.FirstOrDefault(m => m.Id == id);
            return View(merch);
        }

        public IActionResult AddToCart(int id)
        {
            // Logic to add the merchandise item to the shopping cart
            return RedirectToAction("Index");
        }
    }
}
