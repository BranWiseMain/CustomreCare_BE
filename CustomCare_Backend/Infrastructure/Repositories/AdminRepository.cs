using Branwise.Domains.Entites;
using Branwise.Domains.Enums;
using Branwise.Domains.Interfaces;
using Branwise.Services;
using Microsoft.EntityFrameworkCore;

namespace Branwise.Infrastructure.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly CustomCareDbContext _context;

    public AdminRepository(CustomCareDbContext context)
    {
        _context = context;
    }

    public async Task<OpStatus> AddAsync(Admin admin)
    {
        try
        {
            admin.HashedPassword = EncryptionUtils.HashPassword(admin.HashedPassword);
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
            return OpStatus.Success;
        }
        catch { return OpStatus.Failed; }
    }

    public async Task<OpStatus> UpdateAsync(Admin admin)
    {
        try
        {
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();
            return OpStatus.Success;
        }
        catch { return OpStatus.Failed; }
    }

    public async Task<OpStatus> DeleteAsync(Guid id)
    {
        try
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin is null) return OpStatus.NotFound;

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return OpStatus.Success;
        }
        catch { return OpStatus.Failed; }
    }

    public async Task<Admin?> GetByIdAsync(Guid id) => await _context.Admins.FindAsync(id);

    public async Task<Admin?> GetByEmailAsync(string email) =>
        await _context.Admins.FirstOrDefaultAsync(a => a.Email == email);

    public async Task<bool> ValidateLoginAsync(string email, string password)
    {
        var admin = await GetByEmailAsync(email);
        return admin != null && EncryptionUtils.VerifyPassword(password, admin.HashedPassword);
    }
}
