namespace MVCIntro.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
public class SlideController : Controller
{
    [Area("Admin")]
    public IActionResult Index()
    {
        return View();
    }
}
