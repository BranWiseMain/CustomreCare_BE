using Branwise.Domains.Entities;
using Branwise.Domains.Enums;
using Branwise.Domains.Interfaces;
using Branwise.Services;
using Microsoft.EntityFrameworkCore;

namespace Branwise.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly CustomCareDbContext _context;

    public ClientRepository(CustomCareDbContext context)
    {
        _context = context;
    }

    public async Task<OpStatus> AddAsync(Client client)
    {
        try
        {
            if (!string.IsNullOrEmpty(client.ApiKeyHash) && !client.ApiKeyHash.StartsWith("$2"))
                client.ApiKeyHash = EncryptionUtils.HashApiKey(client.ApiKeyHash);

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return OpStatus.Success;
        }
        catch { return OpStatus.Failed; }
    }

    public async Task<OpStatus> UpdateAsync(Client client)
    {
        try
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return OpStatus.Success;
        }
        catch { return OpStatus.Failed; }
    }

    public async Task<OpStatus> DeleteAsync(Guid id)
    {
        try
        {
            var client = await _context.Clients.FindAsync(id);
            if (client is null) return OpStatus.NotFound;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return OpStatus.Success;
        }
        catch { return OpStatus.Failed; }
    }

    public async Task<Client?> GetByApiKeyAsync(string apiKey)
    {
        var clients = await _context.Clients.Where(c => c.IsActive).ToListAsync();
        return clients.FirstOrDefault(c => EncryptionUtils.VerifyApiKey(apiKey, c.ApiKeyHash));
    }

    public async Task<Client?> GetByIdAsync(Guid id) => await _context.Clients.FindAsync(id);
    public async Task<IEnumerable<Client>> GetAllAsync() => await _context.Clients.ToListAsync();
    public async Task<bool> ExistsByNameAsync(string name) => await _context.Clients.AnyAsync(c => c.Name == name);
}