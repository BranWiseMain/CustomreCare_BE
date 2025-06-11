using Branwise.Domains.Common;

namespace Branwise.Domains.Entities;

public class FeedBack : BaseClass
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TenantId { get; set; }
    public string CustomerNumber { get; set; } = default!;
    public string Message { get; set; } = default!;
    public int Rating { get; set; }

    // Relations
    public Client? Client { get; set; }
}
