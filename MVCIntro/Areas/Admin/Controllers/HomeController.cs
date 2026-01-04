namespace MVCIntro.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
public class HomeController : Controller
{
    [Area("Admin")]
    public IActionResult Index()
    {
        return View();
    }
}
