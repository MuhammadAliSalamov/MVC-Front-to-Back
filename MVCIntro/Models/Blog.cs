using MVCIntro.Models.Base;

namespace MVCIntro.Models;

public class Blog : BaseEntity
{
    public string Author { get; set; } = "Admin";
    public DateTime PublishDate { get; set; } 
    public string Title { get; set; } = null!; 
    public string ShortDescription { get; set; } = null!; 
    public string Image { get; set; } = null!;
}