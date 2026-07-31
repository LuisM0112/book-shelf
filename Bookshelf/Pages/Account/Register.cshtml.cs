using Bookshelf.Models;
using Bookshelf.Models.DTOs.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookshelf.Pages.Account;

public class RegisterModel : PageModel
{
  private readonly UserManager<User> _userManager;
  private readonly SignInManager<User> _signInManager;

  public RegisterModel(
    UserManager<User> userManager,
    SignInManager<User> signInManager)
  {
    _userManager = userManager;
    _signInManager = signInManager;
  }

  [BindProperty]
  public RegisterDto Register { get; set; } = new();

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

    User user = new()
    {
      UserName = Register.Username,
      Email = Register.Email
    };

    IdentityResult result = await _userManager.CreateAsync(user, Register.Password);

    if (!result.Succeeded)
    {
      foreach (IdentityError error in result.Errors)
      {
        ModelState.AddModelError(
          string.Empty,
          error.Description);
      }

      return Page();
    }

    await _userManager.AddToRoleAsync(user, "User");

    await _signInManager.SignInAsync(user, isPersistent: false);

    return RedirectToPage("/Index");
  }
}
