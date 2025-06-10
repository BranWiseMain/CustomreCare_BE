using Branwise.Domains.Entities;
using Branwise.Domains.Enums;
using Branwise.Domains.Interfaces;
using Branwise.Services;
using Microsoft.EntityFrameworkCore;

namespace Branwise.Infrastructure.Repositories;

public class FeedBackRepository : IFeedBackRepository
{
    private readonly CustomCareDbContext _context;

    public FeedBackRepository(CustomCareDbContext context)
    {
        _context = context;
    }

    public async Task<OpStatus> AddAsync(FeedBack feedback)
    {
        try
        {
            await _context.FeedBacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
            return OpStatus.Success;
        }
        catch { return OpStatus.Failed; }
    }

    public async Task<OpStatus> DeleteAsync(Guid id)
    {
        try
        {
            var feedback = await _context.FeedBacks.FindAsync(id);
            if (feedback is null) return OpStatus.NotFound;

            _context.FeedBacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return OpStatus.Success;
        }
        catch { return OpStatus.Failed; }
    }

    public async Task<FeedBack?> GetByIdAsync(Guid id) => await _context.FeedBacks.FindAsync(id);

    public async Task<IEnumerable<FeedBack>> GetByTenantIdAsync(Guid tenantId) =>
        await _context.FeedBacks.Where(f => f.TenantId == tenantId).ToListAsync();

    public async Task<IEnumerable<FeedBack>> GetRecentAsync(Guid tenantId, int limit = 10) =>
        await _context.FeedBacks.Where(f => f.TenantId == tenantId)
            .OrderByDescending(f => f.CreatedAt)
            .Take(limit)
            .ToListAsync();
}