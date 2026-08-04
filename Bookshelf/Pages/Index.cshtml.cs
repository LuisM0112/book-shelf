using Bookshelf.Models;
using Bookshelf.Models.DTOs.Books;
using Bookshelf.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookshelf.Pages;

public class IndexModel : PageModel
{
  private readonly IBookService _bookService;
  private readonly UserManager<User> _userManager;

  public IndexModel(
    IBookService bookService,
    UserManager<User> userManager)
  {
    _bookService = bookService;
    _userManager = userManager;
  }

  public IEnumerable<BookListDto> Books { get; private set; }
    = Enumerable.Empty<BookListDto>();

  public async Task OnGetAsync()
  {
    User? user = await _userManager.GetUserAsync(User);
    Books = await _bookService.GetCatalogAsync(user?.Id);
  }
}
