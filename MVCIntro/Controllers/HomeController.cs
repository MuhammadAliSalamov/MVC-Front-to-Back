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
        // Slidlar burada yerlesir
        // Slide slide1 = new Slide { Title = "Summer Collection", Discount = 50, Description = "New Arrivals", Image = "1-1-524x617.png", Order = 1, IsDeleted = false, CreatedAt = DateTime.Now };
        // Slide slide2 = new Slide { Title = "Big Sale", Discount = 70, Description = "Limited Time Offer", Image = "1-2-524x617.png", Order = 2, IsDeleted = false, CreatedAt = DateTime.Now };
        //Categoryler
        // Category category1 = new Category { Name = "Flowers", Products = _context.Products.Where(p => p.IsDeleted == false && p.Categories.Any(c => c.Id == 1)).ToList() };
        // Category category2 = new Category { Name = "Plants", Products = _context.Products.Where(p => p.IsDeleted == false && p.Categories.Any(c => c.Id == 2)).ToList() };
        // Category category3 = new Category { Name = "Gift", Products = _context.Products.Where(p => p.IsDeleted == false && p.Categories.Any(c => c.Id == 3)).ToList() };
        // Category category4 = new Category { Name = "For Home", Products = _context.Products.Where(p => p.IsDeleted == false && p.Categories.Any(c => c.Id == 4)).ToList() };
        //Product-lar burada yerlesir
        // Product p1 = new Product { Name = "American Marigold", Price = 23.45m, PrimaryImage = "1-1-270x300.jpg", SecondaryImage = "1-2-270x300.jpg", Rating = 5, IsDeleted = false, CreatedAt = DateTime.Now , Description = "American Marigold, also known as Tagetes erecta, is a vibrant and cheerful flower native to Mexico and Central America. Known for its bright orange and yellow blooms, it is often used in gardens and floral arrangements to add a splash of color." , Categories = new List<Category> { category1 } };
        // Product p2 = new Product { Name = "Black Rose", Price = 15.00m, PrimaryImage = "1-11-270x300.jpg", SecondaryImage = "1-1-270x300.jpg", Rating = 4, IsDeleted = false, CreatedAt = DateTime.Now , Description = "Black roses are a symbol of mystery, elegance, and farewell. Their deep, dark hue evokes a sense of intrigue and sophistication, making them a unique choice for those looking to make a bold statement." , Categories = new List<Category> { category2 } };
        // Product p3 = new Product { Name = "Red Rose", Price = 10.00m, PrimaryImage = "2-1-270x300.jpg", SecondaryImage = "2-2-270x300.jpg", Rating = 5, IsDeleted = false, CreatedAt = DateTime.Now , Description = "Red roses are the quintessential symbol of love and romance. Their vibrant red petals and intoxicating fragrance have made them a timeless choice for expressing deep emotions and affection." , Categories = new List<Category> { category3 , _context.Categories.FirstOrDefault(c => c.Id == 1) } };
        // Product p4 = new Product { Name = "Yellow Tulip", Price = 12.00m, PrimaryImage = "3-1-270x300.jpg", SecondaryImage = "3-2-270x300.jpg", Rating = 4, IsDeleted = false, CreatedAt = DateTime.Now , Description = "Yellow tulips are a cheerful and vibrant flower that symbolizes happiness, friendship, and new beginnings. Their bright yellow petals bring a sense of warmth and joy to any garden or floral arrangement." , Categories = new List<Category> { category4  , _context.Categories.FirstOrDefault(c => c.Id == 2) } };
        //Blog burada yerlesir
        // Blog b1 = new Blog { Author = "Admin", PublishDate = new DateTime(2021, 4, 24), Title = "There Many Variations", ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore.", Image = "1-1-310x220.jpg", IsDeleted = false, CreatedAt = DateTime.Now };
        // Blog b2 = new Blog { Author = "Admin", PublishDate = new DateTime(2021, 5, 10), Title = "Best Garden Care Tips", ShortDescription = "Discover the secrets of keeping your flowers blooming all year round with our professional guide.", Image = "2-1-370x270.webp", IsDeleted = false, CreatedAt = DateTime.Now };
        // _context.Slides.AddRange(slide1, slide2);
        // _context.Products.AddRange(p3, p4);
        // _context.Blogs.AddRange(b1, b2);
        // _context.Categories.AddRange(category3, category4);
        // _context.SaveChanges();
        HomeVM homeVM = new HomeVM
        {
            Slides = _context.Slides.ToList(),
            Products = _context.Products.ToList(),
            Blogs = _context.Blogs.ToList(),
            Categories = _context.Categories.ToList()
        };
        return View(homeVM);
    }
    public IActionResult NotFound()
    {
        return View();
    }
}
