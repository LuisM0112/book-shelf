using Bookshelf.Data;
using Bookshelf.Models;
using Bookshelf.Models.DTOs.Books;
using Bookshelf.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class BookService : IBookService
{
  private readonly ApplicationDbContext _context;

  public BookService(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<BookListDto>> GetCatalogAsync(string? userId)
  {
    return await _context.Books
      .OrderBy(book => book.Title)
      .Select(book => new BookListDto
      {
        Id = book.Id,
        Title = book.Title,
        Author = book.Author,
        IsFollowing = userId != null &&
          _context.UserBooks.Any(userBook =>
            userBook.UserId == userId &&
            userBook.BookId == book.Id)
      })
      .ToListAsync();
  }

  public async Task<bool> CreateAsync(CreateBookDto createBookDto)
  {
    bool isbnExists = await _context.Books
      .AnyAsync(book => book.ISBN == createBookDto.ISBN);

    if (isbnExists) return false;

    Book book = new()
    {
      Title = createBookDto.Title,
      Author = createBookDto.Author,
      ISBN = createBookDto.ISBN
    };

    await _context.Books.AddAsync(book);

    await _context.SaveChangesAsync();

    return true;
  }

  public async Task<EditBookDto?> GetForEditAsync(int id)
  {
    return await _context.Books
      .Where(book => book.Id == id)
      .Select(book => new EditBookDto
      {
        Id = book.Id,
        Title = book.Title,
        Author = book.Author,
        ISBN = book.ISBN
      })
      .FirstOrDefaultAsync();
  }

  public async Task<bool> UpdateAsync(EditBookDto dto)
  {
    bool isbnExists = await _context.Books.AnyAsync(book =>
      book.ISBN == dto.ISBN &&
      book.Id != dto.Id);

    if (isbnExists)
    {
      return false;
    }

    Book? book = await _context.Books.FindAsync(dto.Id);

    if (book is null)
    {
      return false;
    }

    book.Title = dto.Title;
    book.Author = dto.Author;
    book.ISBN = dto.ISBN;

    await _context.SaveChangesAsync();

    return true;
  }

  public async Task<bool> DeleteAsync(int id)
  {
    Book? book = await _context.Books.FindAsync(id);

    if (book is null)
    {
      return false;
    }

    _context.Books.Remove(book);

    await _context.SaveChangesAsync();

    return true;
  }
}
