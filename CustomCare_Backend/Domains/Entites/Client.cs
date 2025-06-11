using Branwise.Domains.Common;

namespace Branwise.Domains.Entities;

public class Client : BaseClass
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
    public string ApiKeyHash { get; set; } = default!;
    public string? AllowedIPs { get; set; }
    public DateTime? RevokedAt { get; set; }

    // Relations
    public ICollection<IssueReport> IssueReports { get; set; } = new List<IssueReport>();
    public ICollection<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();
}
