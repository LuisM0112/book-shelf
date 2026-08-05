using Bookshelf.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookshelf.Pages.Books;

[Authorize(Roles = "Admin")]
public class DeleteModel : PageModel
{
  private readonly IBookService _bookService;

  public DeleteModel(IBookService bookService)
  {
    _bookService = bookService;
  }

  public async Task<IActionResult> OnPostAsync(int id)
  {
    await _bookService.DeleteAsync(id);

    return RedirectToPage("/Index");
  }
}
