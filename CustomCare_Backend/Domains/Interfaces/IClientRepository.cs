using Branwise.Domains.Entities;
using Branwise.Domains.Enums;

namespace Branwise.Domains.Interfaces;

public interface IClientRepository
{
    Task<Client?> GetByApiKeyAsync(string apiKey);
    Task<Client?> GetByIdAsync(Guid id);
    Task<IEnumerable<Client>> GetAllAsync();
    Task<OpStatus> AddAsync(Client client);
    Task<OpStatus> UpdateAsync(Client client);
    Task<OpStatus> DeleteAsync(Guid id);
    Task<bool> ExistsByNameAsync(string name);
}
