using Branwise.Domains.Common;
using Branwise.Domains.Enums;

namespace Branwise.Domains.Entites;

public class IssueReport : BaseClass
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProviderId { get; set; }
    public string Description { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public ProblemType problemType { get; set; }
    public IssueStatus IStatus { get; set; }
    
    public Provider Provider { get; set; }
    public User User { get; set; }
    //public ICollection<Notification> Notifications { get; set; } // Assuming you have a Notification entity
}
