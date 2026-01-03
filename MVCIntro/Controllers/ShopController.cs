using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCIntro.DAL;
using MVCIntro.Models;
using MVCIntro.ViewModels;

namespace MVCIntro.Controllers;

public class ShopController : Controller
{
    private readonly AppDbContext _context;
    public ShopController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> SinglePage(int id)
    {
        if(id == 0 || id < 0)
        {
            return NotFound();
        }
        Product product = await _context.Products.Include(p => p.Categories).FirstOrDefaultAsync(p => p.Id == id);
        
        if (product == null)
        {
            return NotFound();
        }
        List<Models.Product> relatedProducts = await _context.Products.Where(p => p.Id != id && p.Categories.Any(c => product.Categories.Select(pc => pc.Id).Contains(c.Id))).ToListAsync();
        
        StoreVM storeVM = new StoreVM
        {
            Products = new List<Models.Product> { product },
            RelatedProducts = relatedProducts


        };
        //bunun yolu ile bildim ki relatedin product slideri ozu js faylda dublicate eleyir 4 saat itirdim burda >:(
        // Console.WriteLine("COUNT: " + storeVM.RelatedProducts.Count);
        // Console.WriteLine(string.Join(", ", storeVM.RelatedProducts.Select(p => p.Id)));

        return View(storeVM);
    }
    public IActionResult Wishlist()
    {
        return View();
    }
}
