using Microsoft.AspNetCore.Mvc;

namespace PC_BuyNET.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Manage()
        {
            return View();
        }
    }
}