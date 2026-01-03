using MVCIntro.Models.Base;

namespace MVCIntro.Models;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}
