using Bookshelf.Models;
using Bookshelf.Models.DTOs.Account;
using Bookshelf.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookshelf.Pages.Account;

public class LoginModel : PageModel
{
  private readonly UserManager<User> _userManager;

  private readonly SignInManager<User> _signInManager;

  public LoginModel(
    UserManager<User> userManager,
    SignInManager<User> signInManager)
  {
    _userManager = userManager;
    _signInManager = signInManager;
  }


  [BindProperty]
  public LoginDto Login { get; set; } = new();


  public IActionResult OnGet()
  {
    if (User.Identity?.IsAuthenticated == true)
    {
      return RedirectToPage("/Index");
    }

    return Page();
  }


  public async Task<IActionResult> OnPostAsync()
  {
    if (User.Identity?.IsAuthenticated == true)
    {
      return RedirectToPage("/Index");
    }

    if (!ModelState.IsValid)
    {
      return Page();
    }

    User? user = await _userManager.FindByNameAsync(Login.Identifier);

    user ??= await _userManager.FindByEmailAsync(Login.Identifier);

    if (user is null)
    {
      ModelState.AddModelError(
        string.Empty,
        Messages.User.InvalidCredentials);

      return Page();
    }

    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(
      user,
      Login.Password,
      Login.RememberMe,
      lockoutOnFailure: false);


    if (!result.Succeeded)
    {
      ModelState.AddModelError(string.Empty, Messages.User.InvalidCredentials);

      return Page();
    }

    return RedirectToPage("/Index");
  }
}
