using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bookshelf.Models;

namespace Bookshelf.Pages.Account;

[Authorize]
public class LogoutModel : PageModel
{
  private readonly SignInManager<User> _signInManager;

  public LogoutModel(SignInManager<User> signInManager)
  {
    _signInManager = signInManager;
  }

  public async Task<IActionResult> OnPostAsync()
  {
    await _signInManager.SignOutAsync();

    return RedirectToPage("/Index");
  }
}
