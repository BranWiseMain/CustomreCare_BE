using Branwise.Domains.Common;

namespace Branwise.Domains.Entites;

public class Admin : BaseUser
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
