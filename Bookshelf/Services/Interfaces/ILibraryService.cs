using Bookshelf.Models;
using Bookshelf.Models.DTOs.Library;

namespace Bookshelf.Services.Interfaces;

public interface ILibraryService
{
  Task<bool> FollowAsync(string userId, int bookId);

  Task<IEnumerable<LibraryBookDto>> GetLibraryAsync(string userId);

  Task<bool> UpdateStatusAsync(string userId, int bookId, BookStatus status);

  Task<bool> UpdateRatingAsync(string userId, int bookId, int? rating);

  Task<bool> UnfollowAsync(string userId, int bookId);
}
