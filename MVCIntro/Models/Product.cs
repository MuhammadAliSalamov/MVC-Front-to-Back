using MVCIntro.Models.Base;

namespace MVCIntro.Models;

public class Product : BaseEntity
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? PrimaryImage { get; set; }
    public string? SecondaryImage { get; set; }
    public int Rating { get; set; }
}
