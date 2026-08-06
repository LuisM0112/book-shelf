using System.ComponentModel.DataAnnotations;
using Bookshelf.Helpers;

namespace Bookshelf.Models.DTOs.Proposals;

public class CreateProposalDto
{
  [Required(ErrorMessage = Messages.Book.TitleRequired)]
  [StringLength(200)]
  public string Title { get; set; } = string.Empty;

  [Required(ErrorMessage = Messages.Book.AuthorRequired)]
  [StringLength(150)]
  public string Author { get; set; } = string.Empty;

  [Required]
  public DateOnly ReleaseDate { get; set; }

  [Required(ErrorMessage = Messages.Book.IsbnRequired)]
  [StringLength(17)]
  public string ISBN { get; set; } = string.Empty;
}
