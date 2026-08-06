namespace Bookshelf.Models.DTOs.Proposals;

public class ProposalListDto
{
  public int Id { get; set; }

  public string Title { get; set; } = string.Empty;

  public string Author { get; set; } = string.Empty;

  public DateOnly ReleaseDate { get; set; }

  public string ISBN { get; set; } = string.Empty;

  public string ProposedBy { get; set; } = string.Empty;
}
