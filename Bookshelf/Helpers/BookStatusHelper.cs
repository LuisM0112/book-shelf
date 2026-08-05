using Bookshelf.Models;

namespace Bookshelf.Helpers;

public static class BookStatusHelper
{
  private static readonly IReadOnlyDictionary<BookStatus, string> StatusDictionary =
    new Dictionary<BookStatus, string>
    {
      { BookStatus.Pending, "Pendiente" },
      { BookStatus.Reading, "Leyendo" },
      { BookStatus.Finished, "Completado" },
      { BookStatus.Dropped, "Abandonado" }
    };

  public static string GetDisplayName(BookStatus status)
  {
    return StatusDictionary.TryGetValue(status, out string? displayName)
      ? displayName
      : status.ToString();
  }

  public static IReadOnlyDictionary<BookStatus, string> GetAllStatus()
  {
    return StatusDictionary;
  }
}
