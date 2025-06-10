using Branwise.Domains.Entities;
using Branwise.Domains.Enums;
using Branwise.Domains.Interfaces;
using Branwise.Services;
using Microsoft.EntityFrameworkCore;

namespace Branwise.Infrastructure.Repositories;

public class IssueReportRepository : IIssueReportRepository
{
    private readonly CustomCareDbContext _context;

    public IssueReportRepository(CustomCareDbContext context)
    {
        _context = context;
    }

    public async Task<OpStatus> AddAsync(IssueReport issue)
    {
        try
        {
            await _context.IssueReports.AddAsync(issue);
            await _context.SaveChangesAsync();
            return OpStatus.Success;
        }
        catch { return OpStatus.Failed; }
    }

    public async Task<OpStatus> UpdateAsync(IssueReport issue)
    {
        try
        {
            _context.IssueReports.Update(issue);
            await _context.SaveChangesAsync();
            return OpStatus.Success;
        }
        catch { return OpStatus.Failed; }
    }

    public async Task<OpStatus> DeleteAsync(Guid id)
    {
        try
        {
            var issue = await _context.IssueReports.FindAsync(id);
            if (issue is null) return OpStatus.NotFound;

            _context.IssueReports.Remove(issue);
            await _context.SaveChangesAsync();
            return OpStatus.Success;
        }
        catch { return OpStatus.Failed; }
    }

    public async Task<IssueReport?> GetByIdAsync(Guid id) => await _context.IssueReports.FindAsync(id);
    public async Task<IEnumerable<IssueReport>> GetByTenantIdAsync(Guid tenantId) =>
        await _context.IssueReports.Where(i => i.TenantId == tenantId).ToListAsync();

    public async Task<IEnumerable<IssueReport>> GetRecentByTenantIdAsync(Guid tenantId, int limit = 10) =>
        await _context.IssueReports.Where(i => i.TenantId == tenantId)
            .OrderByDescending(i => i.CreatedAt)
            .Take(limit)
            .ToListAsync();
}
