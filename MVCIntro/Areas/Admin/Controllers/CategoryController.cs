using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCIntro.DAL;
using MVCIntro.Models;

namespace MVCIntro.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    public readonly AppDbContext _context;
    public CategoryController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ActionResult> Index()

    {

        List<Category> categories = await _context.Categories.Include(c => c.Products).ToListAsync();

        return View(categories);
    }

}
