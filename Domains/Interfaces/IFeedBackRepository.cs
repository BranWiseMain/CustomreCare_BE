using Branwise.Domains.Entities;

namespace Branwise.Domains.Interfaces;

public interface IFeedBackRepository : IGenericRepository<FeedBack>
{
    Task<IEnumerable<FeedBack>> GetByTenantIdAsync(Guid tenantId);
    Task<IEnumerable<FeedBack>> GetRecentAsync(Guid tenantId, int limit = 10);
}
