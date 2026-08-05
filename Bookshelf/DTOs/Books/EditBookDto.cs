using System.ComponentModel.DataAnnotations;
using Bookshelf.Helpers;

namespace Bookshelf.Models.DTOs.Books;

public class EditBookDto
{
  public int Id { get; set; }

  [Required(ErrorMessage = Messages.Book.TitleRequired)]
  [StringLength(200)]
  public string Title { get; set; } = string.Empty;

  [Required(ErrorMessage = Messages.Book.AuthorRequired)]
  [StringLength(150)]
  public string Author { get; set; } = string.Empty;

  [Required(ErrorMessage = Messages.Book.IsbnRequired)]
  [StringLength(20)]
  public string ISBN { get; set; } = string.Empty;
}