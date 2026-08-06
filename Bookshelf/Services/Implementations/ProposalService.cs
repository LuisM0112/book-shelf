using Bookshelf.Data;
using Bookshelf.Services.Interfaces;
using Bookshelf.Models;
using Bookshelf.Models.DTOs.Proposals;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Services.Implementations;

public class ProposalService : IProposalService
{
  private readonly ApplicationDbContext _context;

  public ProposalService(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<bool> CreateAsync(CreateProposalDto proposal, string userId)
  {
    bool isbnExists = await _context.Books.AnyAsync(book => book.ISBN == proposal.ISBN);

    if (isbnExists)
    {
      return false;
    }

    bool proposalExists = await _context.BookProposals
    .AnyAsync(bookProposal =>
      bookProposal.ISBN == proposal.ISBN &&
      bookProposal.Status == ProposalStatus.Pending);

    if (proposalExists)
    {
      return false;
    }

    BookProposal bookProposal = new()
    {
      Title = proposal.Title,
      Author = proposal.Author,
      ReleaseDate = proposal.ReleaseDate,
      ISBN = proposal.ISBN,
      UserId = userId
    };

    _context.BookProposals.Add(bookProposal);

    await _context.SaveChangesAsync();

    return true;
  }

  public async Task<IEnumerable<ProposalListDto>> GetPendingAsync()
  {
    return await _context.BookProposals
      .Where(proposal => proposal.Status == ProposalStatus.Pending)
      .OrderBy(proposal => proposal.Title)
      .Select(proposal => new ProposalListDto
      {
        Id = proposal.Id,
        Title = proposal.Title,
        Author = proposal.Author,
        ReleaseDate = proposal.ReleaseDate,
        ISBN = proposal.ISBN,
        ProposedBy = proposal.User.UserName!
      })
      .ToListAsync();
  }

  public async Task<bool> AcceptAsync(int proposalId)
  {
    BookProposal? proposal = await _context.BookProposals
      .FirstOrDefaultAsync(proposal => proposal.Id == proposalId);

    if (proposal is null)
    {
      return false;
    }

    bool isbnExists = await _context.Books
      .AnyAsync(book => book.ISBN == proposal.ISBN);

    if (isbnExists)
    {
      return false;
    }

    Book book = new()
    {
      Title = proposal.Title,
      Author = proposal.Author,
      ReleaseDate = proposal.ReleaseDate,
      ISBN = proposal.ISBN
    };

    _context.Books.Add(book);

    proposal.Status = ProposalStatus.Accepted;

    await _context.SaveChangesAsync();

    return true;
  }

  public Task<bool> RejectAsync(int proposalId)
  {
    throw new NotImplementedException();
  }
}
