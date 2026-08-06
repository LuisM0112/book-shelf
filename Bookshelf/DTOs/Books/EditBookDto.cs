using System.ComponentModel.DataAnnotations;
using Bookshelf.Helpers;

namespace Bookshelf.Models.DTOs.Books;

public class EditBookDto
{
  public int Id { get; set; }

  [Required(ErrorMessage = Messages.Book.TitleRequired)]
  [StringLength(200)]
  [Display(Name = "Titulo")]
  public string Title { get; set; } = string.Empty;

  [Required(ErrorMessage = Messages.Book.AuthorRequired)]
  [StringLength(150)]
  [Display(Name = "Autor")]
  public string Author { get; set; } = string.Empty;
  [Required(ErrorMessage = Messages.Book.DateRequired)]
  [Display(Name = "Fecha de publicación")]
  public DateOnly ReleaseDate { get; set; }

  [Required(ErrorMessage = Messages.Book.IsbnRequired)]
  [StringLength(20)]
  public string ISBN { get; set; } = string.Empty;
}