using Bookshelf.Data;
using Bookshelf.Models;
using Bookshelf.Models.DTOs.Library;
using Bookshelf.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Services.Implementations;

public class LibraryService : ILibraryService
{
  private readonly ApplicationDbContext _context;

  public LibraryService(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<bool> FollowAsync(string userId, int bookId)
  {
    Book? book = await _context.Books.FindAsync(bookId);

    if (book is null)
    {
        return false;
    }

    bool alreadyFollowing = await _context.UserBooks.AnyAsync(userBook =>
      userBook.UserId == userId &&
      userBook.BookId == bookId);

    if (alreadyFollowing)
    {
      return false;
    }

    UserBook userBook = new()
    {
      UserId = userId,
      BookId = bookId,
      Status = BookStatus.Pending
    };

    await _context.UserBooks.AddAsync(userBook);

    await _context.SaveChangesAsync();

    return true;
  }

  public async Task<IEnumerable<LibraryBookDto>> GetLibraryAsync(string userId)
  {
    return await _context.UserBooks
      .Where(userBook => userBook.UserId == userId)
      .Select(userBook => new LibraryBookDto
      {
        BookId = userBook.BookId,
        Title = userBook.Book.Title,
        Author = userBook.Book.Author,
        Status = userBook.Status,
        Rating = userBook.Rating
      })
      .OrderBy(book => book.Title)
      .ToListAsync();
  }

  public Task<bool> UnfollowAsync(string userId, int bookId)
  {
    throw new NotImplementedException();
  }

  public Task<bool> UpdateRatingAsync(string userId, int bookId, int? rating)
  {
    throw new NotImplementedException();
  }

  public Task<bool> UpdateStatusAsync(string userId, int bookId, BookStatus status)
  {
    throw new NotImplementedException();
  }
}
