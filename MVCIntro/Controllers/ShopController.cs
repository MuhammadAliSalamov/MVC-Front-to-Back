using Microsoft.AspNetCore.Mvc;

namespace MVCIntro.Controllers;

public class ShopController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult SinglePage()
    {
        return View();
    }
    public IActionResult Wishlist()
    {
        return View();
    }
}
