using System.Security.Claims;
using Bookshelf.Helpers;
using Bookshelf.Models.DTOs.Proposals;
using Bookshelf.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookshelf.Pages.Proposals;

[Authorize]
public class CreateModel : PageModel
{
  private readonly IProposalService _proposalService;

  public CreateModel(IProposalService proposalService)
  {
    _proposalService = proposalService;
  }

  [BindProperty]
  public CreateProposalDto Proposal { get; set; } = new();

  public void OnGet()
  {
  }

  public async Task<IActionResult> OnPostAsync()
  {
    if (!ModelState.IsValid)
    {
      return Page();
    }

    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

    bool created = await _proposalService.CreateAsync(Proposal, userId);

    if (!created)
    {
      ModelState.AddModelError(
        string.Empty,
        Messages.Proposal.DuplicateProposal);

      return Page();
    }

    return RedirectToPage("/Index");
  }
}