namespace Bookshelf.Models.DTOs.Library;

public class LibraryBookDto
{
  public int BookId { get; set; }

  public string Title { get; set; } = string.Empty;

  public string Author { get; set; } = string.Empty;

  public BookStatus Status { get; set; }

  public int? Rating { get; set; }
}
