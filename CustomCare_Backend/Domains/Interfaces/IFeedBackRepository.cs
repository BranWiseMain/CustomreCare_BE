using Branwise.Domains.Entities;
using Branwise.Domains.Enums;

namespace Branwise.Domains.Interfaces;

public interface IFeedBackRepository
{
    Task<FeedBack?> GetByIdAsync(Guid id);
    Task<IEnumerable<FeedBack>> GetByTenantIdAsync(Guid tenantId);
    Task<IEnumerable<FeedBack>> GetRecentAsync(Guid tenantId, int limit = 10);
    Task<OpStatus> AddAsync(FeedBack feedback);
    Task<OpStatus> DeleteAsync(Guid id);
}
