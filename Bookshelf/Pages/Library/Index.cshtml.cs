using System.Security.Claims;
using Bookshelf.Models;
using Bookshelf.Models.DTOs.Library;
using Bookshelf.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookshelf.Pages.Library;

[Authorize]
public class IndexModel : PageModel
{
  private readonly ILibraryService _libraryService;

  public IndexModel(ILibraryService libraryService)
  {
    _libraryService = libraryService;
  }

  public IEnumerable<LibraryBookDto> Books { get; private set; } = [];

  public async Task OnGetAsync()
  {
    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

    Books = await _libraryService.GetLibraryAsync(userId);
  }

  public async Task<IActionResult> OnPostStatusAsync(int bookId, BookStatus status)
  {
    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

    await _libraryService.UpdateStatusAsync(userId, bookId, status);

    return RedirectToPage();
  }

  public async Task<IActionResult> OnPostRatingAsync(int bookId, int? rating)
  {
    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

    await _libraryService.UpdateRatingAsync(userId, bookId, rating);

    return RedirectToPage();
  }
}
