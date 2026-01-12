using System.Net.Mime;
using System.ComponentModel.DataAnnotations;
using MVCIntro.Areas.Admin.ViewModels.Base;

namespace MVCIntro.Areas.Admin.ViewModels.Slider;

public class CreateSlideVM : VMBaseEntity
{
    [Required(ErrorMessage = "Title is required")]
    [MaxLength(30, ErrorMessage = "Title 30dan cox yazmaq olmaz")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Discount is required")]
    public int Discount { get; set; }
    [Required(ErrorMessage = "Description is required")]
    [MaxLength(300, ErrorMessage = "Description 300 dan cox yazmaq olmaz")]
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile? Image { get; set; }
    [Required(ErrorMessage = "Order is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Order must be greater than 0")]
    public int Order { get; set; }
}
