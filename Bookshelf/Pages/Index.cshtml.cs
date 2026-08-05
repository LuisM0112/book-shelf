using System.Security.Claims;
using Bookshelf.Models;
using Bookshelf.Models.DTOs.Books;
using Bookshelf.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookshelf.Pages;

public class IndexModel : PageModel
{
  private readonly IBookService _bookService;
  private readonly ILibraryService _libraryService;
  private readonly UserManager<User> _userManager;

  public IndexModel(
    IBookService bookService,
    ILibraryService libraryService,
    UserManager<User> userManager)
  {
    _bookService = bookService;
    _libraryService = libraryService;
    _userManager = userManager;
  }

  public IEnumerable<BookListDto> Books { get; private set; }
    = Enumerable.Empty<BookListDto>();

  public async Task OnGetAsync()
  {
    User? user = await _userManager.GetUserAsync(User);
    Books = await _bookService.GetCatalogAsync(user?.Id);
  }

  private string? GetUserId()
  {
    return User.FindFirstValue(ClaimTypes.NameIdentifier);
  }

  public async Task<IActionResult> OnPostFollowAsync(int id)
  {
    string? userId = GetUserId();
    if (userId is null)
    {
      return Challenge();
    }

    await _libraryService.FollowAsync(userId, id);

    return RedirectToPage();
  }

  public async Task<IActionResult> OnPostUnfollowAsync(int id)
  {
    string? userId = GetUserId();

    if (userId is null)
    {
      return Challenge();
    }

    await _libraryService.UnfollowAsync(userId, id);

    return RedirectToPage();
  }
}
