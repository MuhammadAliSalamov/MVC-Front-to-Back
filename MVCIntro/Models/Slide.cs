namespace MVCIntro.Models;

public class Slide : Base.BaseEntity
{
    public string Title { get; set; }
    public int Discount { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int Order { get; set; }
}
