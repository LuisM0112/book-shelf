using Bookshelf.Helpers;
using Bookshelf.Models.DTOs.Books;
using Bookshelf.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookshelf.Pages.Books;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
  private readonly IBookService _bookService;

  public EditModel(IBookService bookService)
  {
    _bookService = bookService;
  }

  [BindProperty]
  public EditBookDto Book { get; set; } = new();

  public async Task<IActionResult> OnGetAsync(int id)
  {
    EditBookDto? book = await _bookService.GetForEditAsync(id);

    if (book is null)
    {
      return NotFound();
    }

    Book = book;

    return Page();
  }

  public async Task<IActionResult> OnPostAsync()
  {
    if (!ModelState.IsValid)
    {
      return Page();
    }

    if (!await _bookService.UpdateAsync(Book))
    {
      ModelState.AddModelError(
        string.Empty,
        Messages.Book.IsbnAlreadyExists);

      return Page();
    }

    return RedirectToPage("/Index");
  }
}