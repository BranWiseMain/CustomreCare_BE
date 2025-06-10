using Branwise.Domains.Entites;
using Branwise.Domains.Enums;

namespace Branwise.Domains.Interfaces;

public interface IAdminRepository
{
    Task<Admin?> GetByIdAsync(Guid id);
    Task<Admin?> GetByEmailAsync(string email);
    Task<bool> ValidateLoginAsync(string email, string password);
    Task<OpStatus> AddAsync(Admin admin);
    Task<OpStatus> UpdateAsync(Admin admin);
    Task<OpStatus> DeleteAsync(Guid id);
}
