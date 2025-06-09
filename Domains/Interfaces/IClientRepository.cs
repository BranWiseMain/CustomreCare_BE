using Branwise.Domains.Entities;


namespace Branwise.Domains.Interfaces;
public interface IClientRepository : IGenericRepository<Client>
{
    Task<Client?> GetByApiKeyAsync(string apiKey);
    Task<bool> ExistsByNameAsync(string name);
}

