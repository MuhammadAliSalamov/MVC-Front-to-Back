using MVCIntro.Models;

namespace MVCIntro.ViewModels;

public class StoreVM
{
    public List<Category>? Categories { get; set; }
    public List<Product>? Products { get; set; }
    public List<Product>? RelatedProducts { get; set; } = new();

}
