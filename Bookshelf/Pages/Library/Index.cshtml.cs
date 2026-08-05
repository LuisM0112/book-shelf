using System.Security.Claims;
using Bookshelf.Models.DTOs.Library;
using Bookshelf.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
}
