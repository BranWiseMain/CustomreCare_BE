using Branwise.Domains.Entities;
using Branwise.Domains.Enums;

namespace Branwise.Domains.Interfaces;

public interface IIssueReportRepository
{
    Task<IssueReport?> GetByIdAsync(Guid id);
    Task<IEnumerable<IssueReport>> GetByTenantIdAsync(Guid tenantId);
    Task<IEnumerable<IssueReport>> GetRecentByTenantIdAsync(Guid tenantId, int limit = 10);
    Task<OpStatus> AddAsync(IssueReport issue);
    Task<OpStatus> UpdateAsync(IssueReport issue);
    Task<OpStatus> DeleteAsync(Guid id);
}
