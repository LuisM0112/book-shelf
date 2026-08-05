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

  public async Task<IActionResult> OnPostFollowAsync(int id)
  {
    if (!User.Identity?.IsAuthenticated ?? true)
    {
      return Challenge();
    }

    string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

    if (userId is null)
    {
      return Challenge();
    }

    await _libraryService.FollowAsync(userId, id);

    return RedirectToPage();
  }
}
