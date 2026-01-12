using System.ComponentModel.DataAnnotations;
using MVCIntro.Areas.Admin.ViewModels.Base;
using MVCIntro.Models;
namespace MVCIntro.Areas.Admin.ViewModels.Category;

public class UpdateCategoryVM : VMBaseEntity
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(30, ErrorMessage = "Name 30dan cox yazmaq olmaz")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Description is required")]
    [MaxLength(300, ErrorMessage = "Description 300 dan cox yazmaq olmaz")]
    public string? Description { get; set; }
    public ICollection<Product>? Products { get; set; }
}
