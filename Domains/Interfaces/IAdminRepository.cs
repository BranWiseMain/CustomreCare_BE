using Branwise.Domains.Entites;

namespace Branwise.Domains.Interfaces;

public interface IAdminRepository : IGenericRepository<Admin>
{
    Task<Admin?> GetByEmailAsync(string email);
    Task<bool> ValidateLoginAsync(string email, string hashedPassword);
}
