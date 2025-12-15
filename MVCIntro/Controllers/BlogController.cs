using Microsoft.AspNetCore.Mvc;
namespace MVCIntro.Controllers;

public class BlogController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
