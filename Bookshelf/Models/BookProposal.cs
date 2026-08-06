using System.ComponentModel.DataAnnotations;

namespace Bookshelf.Models;

public class BookProposal
{
  public int Id { get; set; }

  [StringLength(200)]
  public string Title { get; set; } = string.Empty;

  [StringLength(150)]
  public string Author { get; set; } = string.Empty;

  public DateOnly ReleaseDate { get; set; }

  [StringLength(17)]
  public string ISBN { get; set; } = string.Empty;

  public string UserId { get; set; } = string.Empty;

  public User User { get; set; } = null!;

  public ProposalStatus Status { get; set; } = ProposalStatus.Pending;
}