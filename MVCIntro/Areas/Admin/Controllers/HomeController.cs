namespace MVCIntro.Areas.Admin.Controllers;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
public class HomeController : Controller
{
    [Area("Admin")]
    [Authorize(Roles = "Admin , Moderator")]
    public IActionResult Index()
    {
        return View();
    }
}
