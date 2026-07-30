using System.ComponentModel.DataAnnotations;

namespace Bookshelf.Models;

public class Book
{
  public int Id { get; set; }

  [StringLength(200)]
  public string Title { get; set; } = string.Empty;

  [StringLength(150)]
  public string Author { get; set; } = string.Empty;

  public DateOnly ReleaseDate { get; set; }

  [StringLength(17)]
  public string ISBN { get; set; } = string.Empty;
}