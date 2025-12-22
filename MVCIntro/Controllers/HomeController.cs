using Microsoft.AspNetCore.Mvc;
using MVCIntro.Models;
using MVCIntro.ViewModels;

namespace MVCIntro.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Slidlar burada yerlesir
        Slide slide1 = new Slide { Id = 1, Title = "Summer Collection", Discount = 50, Description = "New Arrivals", Image = "1-1-524x617.png", Order = 1, IsDeleted = false, CreatedAt = DateTime.Now };
        Slide slide2 = new Slide { Id = 2, Title = "Big Sale", Discount = 70, Description = "Limited Time Offer", Image = "1-2-524x617.png", Order = 2, IsDeleted = false, CreatedAt = DateTime.Now };
        //Product-lar burada yerlesir
        Product p1 = new Product { Id = 1, Name = "American Marigold", Price = 23.45m, PrimaryImage = "1-1-270x300.jpg", SecondaryImage = "1-2-270x300.jpg", Rating = 5, IsDeleted = false, CreatedAt = DateTime.Now };
        Product p2 = new Product { Id = 2, Name = "Black Rose", Price = 15.00m, PrimaryImage = "1-11-270x300.jpg", SecondaryImage = "1-1-270x300.jpg", Rating = 4, IsDeleted = false, CreatedAt = DateTime.Now };
        //Blog burada yerlesir
        Blog b1 = new Blog { Id = 1, Author = "Admin", PublishDate = new DateTime(2021, 4, 24), Title = "There Many Variations", ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore.", Image = "1-1-310x220.jpg", IsDeleted = false, CreatedAt = DateTime.Now };
        Blog b2 = new Blog { Id = 2, Author = "Admin", PublishDate = new DateTime(2021, 5, 10), Title = "Best Garden Care Tips", ShortDescription = "Discover the secrets of keeping your flowers blooming all year round with our professional guide.", Image = "2-1-370x270.webp", IsDeleted = false, CreatedAt = DateTime.Now };
        HomeVM homeVM = new HomeVM
        {
            Slides = new List<Slide> { slide1, slide2 },
            Products = new List<Product> { p1, p2 },
            Blogs = new List<Blog> { b1, b2 }
        };
        return View(homeVM);
    }
    public IActionResult NotFound()
    {
        return View();
    }
}
