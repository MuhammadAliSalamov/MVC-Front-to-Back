using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCIntro.Areas.Admin.ViewModels.Category;
using MVCIntro.DAL;
using MVCIntro.Models;

namespace MVCIntro.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin , Moderator")]
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
    public ActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create(CreateCategoryVM createCategoryVM)
    {
        if (!ModelState.IsValid)
        {
            return View();
        } 
        bool doesExist = await _context.Categories.AnyAsync(c => c.Name.ToLower() == createCategoryVM.Name.ToLower());
        if (doesExist)
        {
            ModelState.AddModelError("Name", "This category already exists");
            return View();
        }
        Category category = new Category
        {
            Name = createCategoryVM.Name,
            Description = createCategoryVM.Description,
            CreatedAt = DateTime.Now,
            IsDeleted = false
        };
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return NotFound();

        UpdateCategoryVM updateCategoryVM = new UpdateCategoryVM
        {
            Name = category.Name,
            Description = category.Description,
            Products = category.Products
        };
        return View(updateCategoryVM);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(int id, UpdateCategoryVM updateCategoryVM)
    {
        if (!ModelState.IsValid)
        {
            return View(updateCategoryVM);    
        }
        if (id != updateCategoryVM.Id)
        {
            return BadRequest();
        }
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();   
        }
        category.Name = updateCategoryVM.Name;
        category.Description = updateCategoryVM.Description;
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Details(int id)
    {
        var category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }


}
