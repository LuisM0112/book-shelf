using System.ComponentModel.DataAnnotations;

namespace Bookshelf.Models;

public class UserBook
{
  public int Id { get; set; }

  public string UserId { get; set; } = string.Empty;

  public User User { get; set; } = null!;

  public int BookId { get; set; }

  public Book Book { get; set; } = null!;

  public BookStatus Status { get; set; }

  [Range(1, 5)]
  public int? Rating { get; set; }
}