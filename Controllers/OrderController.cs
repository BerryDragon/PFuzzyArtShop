using Microsoft.AspNetCore.Mvc;

namespace PFuzzyArtShop.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
