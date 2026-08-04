using Bookshelf.Helpers;
using Bookshelf.Models.DTOs.Books;
using Bookshelf.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookshelf.Pages.Books;

[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
{
  private readonly IBookService _bookService;

  public CreateModel(IBookService bookService)
  {
    _bookService = bookService;
  }

  [BindProperty]
  public CreateBookDto Book { get; set; } = new();

  public void OnGet()
  {
  }

  public async Task<IActionResult> OnPostAsync()
  {
    if (!ModelState.IsValid)
    {
      return Page();
    }

    if (!await _bookService.CreateAsync(Book))
    {
      ModelState.AddModelError(
        string.Empty,
        Messages.Book.IsbnAlreadyExists);

      return Page();
    }

    await _bookService.CreateAsync(Book);

    return RedirectToPage("/Index");
  }
}