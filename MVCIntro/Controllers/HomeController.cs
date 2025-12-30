using Microsoft.AspNetCore.Mvc;
using MVCIntro.DAL;
using MVCIntro.Models;
using MVCIntro.ViewModels;

namespace MVCIntro.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        // // Slidlar burada yerlesir
        // Slide slide1 = new Slide { Title = "Summer Collection", Discount = 50, Description = "New Arrivals", Image = "1-1-524x617.png", Order = 1, IsDeleted = false, CreatedAt = DateTime.Now };
        // Slide slide2 = new Slide { Title = "Big Sale", Discount = 70, Description = "Limited Time Offer", Image = "1-2-524x617.png", Order = 2, IsDeleted = false, CreatedAt = DateTime.Now };
        // //Product-lar burada yerlesir
        // Product p1 = new Product { Name = "American Marigold", Price = 23.45m, PrimaryImage = "1-1-270x300.jpg", SecondaryImage = "1-2-270x300.jpg", Rating = 5, IsDeleted = false, CreatedAt = DateTime.Now };
        // Product p2 = new Product { Name = "Black Rose", Price = 15.00m, PrimaryImage = "1-11-270x300.jpg", SecondaryImage = "1-1-270x300.jpg", Rating = 4, IsDeleted = false, CreatedAt = DateTime.Now };
        // //Blog burada yerlesir
        // Blog b1 = new Blog { Author = "Admin", PublishDate = new DateTime(2021, 4, 24), Title = "There Many Variations", ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore.", Image = "1-1-310x220.jpg", IsDeleted = false, CreatedAt = DateTime.Now };
        // Blog b2 = new Blog { Author = "Admin", PublishDate = new DateTime(2021, 5, 10), Title = "Best Garden Care Tips", ShortDescription = "Discover the secrets of keeping your flowers blooming all year round with our professional guide.", Image = "2-1-370x270.webp", IsDeleted = false, CreatedAt = DateTime.Now };
        // _context.Slides.AddRange(slide1, slide2);
        // _context.Products.AddRange(p1, p2);
        // _context.Blogs.AddRange(b1, b2);
        // _context.SaveChanges();
        HomeVM homeVM = new HomeVM
        {
            Slides = _context.Slides.ToList(),
            Products = _context.Products.ToList(),
            Blogs = _context.Blogs.ToList()
        };
        return View(homeVM);
    }
    public IActionResult NotFound()
    {
        return View();
    }
}
