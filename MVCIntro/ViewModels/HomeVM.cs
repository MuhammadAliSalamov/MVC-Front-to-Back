using MVCIntro.Models;

namespace MVCIntro.ViewModels;

public class HomeVM
{
    public List<Slide>? Slides { get; set; }
    public List<Product>? Products { get; internal set; }
    public List<Blog>? Blogs { get; internal set; }
    public List<Category> Categories { get; internal set; }

}
