using Bookshelf.Models.DTOs.Proposals;
using Bookshelf.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookshelf.Pages.Proposals;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
  private readonly IProposalService _proposalService;

  public IndexModel(IProposalService proposalService)
  {
    _proposalService = proposalService;
  }

  public IEnumerable<ProposalListDto> Proposals { get; private set; }
    = Enumerable.Empty<ProposalListDto>();

  public async Task OnGetAsync()
  {
    Proposals = await _proposalService.GetPendingAsync();
  }
}
