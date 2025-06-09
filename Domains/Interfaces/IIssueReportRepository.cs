using Branwise.Domains.Interfaces;
using Branwise.Domains.Entities;

namespace Domains.Interfaces;

public interface IIssueReportRepository : IGenericRepository<IssueReport>
{
    Task<IEnumerable<IssueReport>> GetByTenantIdAsync(Guid tenantId);
    Task<IEnumerable<IssueReport>> GetRecentByTenantIdAsync(Guid tenantId, int limit = 10);
}
