namespace MVCIntro.Areas.Admin.Controllers;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCIntro.Areas.Admin.ViewModels.Slider;
using MVCIntro.DAL;
using MVCIntro.Models;
using MVCIntro.Utilities.Enums;
using MVCIntro.Utilities.Extensions;


[Area("Admin")]
[Authorize(Roles = "Admin , Moderator")]
public class SlideController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _env;
    public SlideController(AppDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }
    public async Task<IActionResult> Index()
    {
        List<Slide> slides = await _context.Slides.ToListAsync();
        return View(slides);
    }
    public ActionResult Create()
    {
        return View();
    }
    [HttpPost]

    public async Task<ActionResult> Create(CreateSlideVM createSlideVM)
    {
        if (!ModelState.IsValid)
        {
            return View();
        } 
        bool doesExist = await _context.Categories.AnyAsync(c => c.Name.ToLower() == createSlideVM.Title.ToLower());
        if (doesExist)
        {
            ModelState.AddModelError("Name", "This category already exists");
            return View();
        }

        if (!createSlideVM.Image.ValidateType("image/"))
        {
            ModelState.AddModelError("ImageFile", "Please select image file type");
            return View(createSlideVM);
        }

        if (createSlideVM.Image.ValidateSize(FileSizes.KB, 2048))
        {
            ModelState.AddModelError("ImageFile", "Image size must be max 2MB");
            return View(createSlideVM);
        }

        Slide slide = new Slide
        {
            Title = createSlideVM.Title,
            Description = createSlideVM.Description,
            Discount = createSlideVM.Discount,
            ImageUrl = await createSlideVM.Image.CreateFile(_env.WebRootPath, "assets", "images", "slider"),
            Order = createSlideVM.Order,
            CreatedAt = DateTime.Now,
            IsDeleted = false
        };
        await _context.Slides.AddAsync(slide);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var slide = await _context.Slides.FindAsync(id);
        if (slide == null) return NotFound();

        ViewBag.Categories = await _context.Categories.ToListAsync();

        UpdateSlideVM updateSlide = new UpdateSlideVM
        {
            Id = slide.Id,
            Title = slide.Title,
            Description = slide.Description,
            Discount = slide.Discount,
            ImageUrl = slide.ImageUrl
        };
        return View(updateSlide);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, UpdateSlideVM updateSlide)
    {
        if (id != updateSlide.Id) return BadRequest();
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(updateSlide);
        }

        Slide slide = await _context.Slides.FindAsync(id);
        if (slide == null) return NotFound();
        if (updateSlide.Image != null)
        {
            if (!updateSlide.Image.ValidateType("image/"))
            {
                ModelState.AddModelError("ImageFile", "Please select image file type");
                return View(updateSlide);
            }
            if (updateSlide.Image.ValidateSize(FileSizes.KB, 2048))
            {
                ModelState.AddModelError("ImageFile", "Image size must be max 2MB");
                return View(updateSlide);
            }

            slide.ImageUrl.DeleteFile(_env.WebRootPath, "image", "products");
            slide.ImageUrl = await updateSlide.Image.CreateFile(_env.WebRootPath, "image", "products");
        }

        slide.Title = updateSlide.Title;
        slide.Description = updateSlide.Description;
        slide.Discount = (int)updateSlide.Discount;
        slide.Order = (int)updateSlide.Order;

        _context.Slides.Update(slide);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        Slide slide = await _context.Slides.FindAsync(id);
        if (slide == null) return NotFound();

        if (!string.IsNullOrEmpty(slide.ImageUrl))
        {
            slide.ImageUrl.DeleteFile(_env.WebRootPath, "image", "products");
        }

        _context.Slides.Remove(slide);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        var slide = await _context.Slides.FirstOrDefaultAsync(p => p.Id == id);
        if (slide == null) return NotFound();

        return View(slide);
    }

}
