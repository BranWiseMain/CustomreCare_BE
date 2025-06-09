using Branwise.Domains.Common;
using Branwise.Domains.Enums;

namespace Branwise.Domains.Entities;

public class IssueReport : BaseClass
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TenantId { get; set; }
    public string CustomerNumber { get; set; } = default!;
    public ProblemType IssueType { get; set; } = default!;
    public string? Description { get; set; }
    public IssueStatus Status { get; set; } = 0; // Pending, Resolved, Failed
    public string? ResolutionResponse { get; set; }

    // Relations
    public Client? Client { get; set; }
}
