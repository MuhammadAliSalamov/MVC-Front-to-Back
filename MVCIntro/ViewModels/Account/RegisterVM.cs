using System.ComponentModel.DataAnnotations;

namespace MVCIntro.ViewModels.Account;

public class RegisterVM
{
    [Required (ErrorMessage = "Name is required")]
    [MaxLength(30 , ErrorMessage ="Name 30 dan cox ola bilmez")]
    public string Name { get; set; }
    [Required (ErrorMessage = "Surname is required")]
    [MaxLength (30 , ErrorMessage = "Surname 30 dan cox ola bilmez")]
    
    public string Surname { get; set; }
    [Required (ErrorMessage = "Username is required")]
    [MaxLength (30 , ErrorMessage = "Username 30 dan cox ola bilmez")]
    public string UserName { get; set; }
    [Required (ErrorMessage = "Email is required")]
    [EmailAddress (ErrorMessage = "Duzgun formatda email daxil edin")]
    public string Email { get; set; }
    [Required (ErrorMessage = "Password is required")]
    [DataType (DataType.Password)]

    public string Password { get; set; }
    [Required (ErrorMessage = "Confirm Password is required")]
    [DataType (DataType.Password)]
    [Compare ("Password", ErrorMessage ="Password ve Confirm Password eyni olmalidir")]
    public string ConfirmPassword { get; set; }
}
