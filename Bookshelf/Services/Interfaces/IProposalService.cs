using Bookshelf.Models.DTOs.Proposals;

namespace Bookshelf.Services.Interfaces;

public interface IProposalService
{
  Task<IEnumerable<ProposalListDto>> GetPendingAsync();

  Task<bool> CreateAsync(CreateProposalDto proposal, string userId);

  Task<bool> AcceptAsync(int proposalId);

  Task<bool> RejectAsync(int proposalId);
}
