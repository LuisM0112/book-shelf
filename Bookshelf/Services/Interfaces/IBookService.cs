using Bookshelf.Models.DTOs.Books;

namespace Bookshelf.Services.Interfaces;

public interface IBookService
{
  Task<IEnumerable<BookListDto>> GetCatalogAsync(string? userId);

  Task<bool> CreateAsync(CreateBookDto createBookDto);

  Task<EditBookDto?> GetForEditAsync(int id);

  Task<bool> UpdateAsync(EditBookDto dto);
}
