using Bookshelf.Models;
using Bookshelf.Models.DTOs.Account;
using Bookshelf.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookshelf.Pages.Account;

[Authorize]
public class DeleteModel : PageModel
{
  private readonly UserManager<User> _userManager;
  private readonly SignInManager<User> _signInManager;

  public DeleteModel(
    UserManager<User> userManager,
    SignInManager<User> signInManager)
  {
    _userManager = userManager;
    _signInManager = signInManager;
  }

  [BindProperty]
  public DeleteAccountDto Delete { get; set; } = new();

  public async Task<IActionResult> OnGetAsync()
  {
    User? user = await _userManager.GetUserAsync(User);

    if (user is null)
    {
      return RedirectToPage("/Index");
    }

    return Page();
  }

  public async Task<IActionResult> OnPostAsync()
  {
    if (!ModelState.IsValid)
    {
      return Page();
    }

    User? user = await _userManager.GetUserAsync(User);

    if (user is null)
    {
      return RedirectToPage("/Index");
    }

    if (Delete.Username != user.UserName)
    {
      ModelState.AddModelError(
        string.Empty,
        Messages.Account.UsernameMismatch);

      return Page();
    }

    await _signInManager.SignOutAsync();

    IdentityResult result = await _userManager.DeleteAsync(user);

    if (!result.Succeeded)
    {
      ModelState.AddModelError(
        string.Empty,
        Messages.Account.DeleteFailed);

      return Page();
    }

    return RedirectToPage("/Index");
  }
}
