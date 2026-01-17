using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCIntro.Models;
using MVCIntro.Utilities.Enums;
using MVCIntro.ViewModels.Account;

namespace MVCIntro.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager , RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
        if (!ModelState.IsValid)
        {
            return View(registerVM);
        }
        if (registerVM.Password != registerVM.ConfirmPassword)
        {
            ModelState.AddModelError("ConfirmPassword", "Password and Confirm Password do not match.");
            return View(registerVM);
        }
        AppUser appUser = new()
        {
            UserName = registerVM.UserName,
            Name = registerVM.Name,
            Surname = registerVM.Surname,
            Email = registerVM.Email,
        };

        IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);

        if (!result.Succeeded)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(registerVM);
        }

        await _userManager.AddToRoleAsync(appUser, UserRoles.Member.ToString());
        await _signInManager.SignInAsync(appUser, isPersistent: false);
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    public async Task<IActionResult> Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> Login(LoginVM loginVM)
    {

        if (!ModelState.IsValid)
        {
            return View();
        }
        AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginVM.UserNameOrEmail || u.Email == loginVM.UserNameOrEmail);

        if (user == null)
        {
            ModelState.AddModelError("", "usernae or mail invalid");
            return View();
        }
        var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.IsPersisted, true);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "password invalid");
            return View();
        }


        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
    public async Task<IActionResult> CreateRoles()
    {
        foreach(UserRoles role in Enum.GetValues(typeof(UserRoles)))
        {
            if (!await _roleManager.RoleExistsAsync(role.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
            }
        }
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

}
