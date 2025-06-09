using Branwise.Domains.Enums;

namespace Branwise.Domains.Common;

public abstract class BaseClass
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = true;
    

}
