using Branwise.Domains.Common;

namespace Branwise.Domains.Entites;

public class User : BaseUser
{
    public int Id { get; set; }
    public int ProviderId { get; set; }
    public Provider Provider { get; set; }



    public ICollection<IssueReport> IssueReports { get; set; }
    public ICollection<FeedBack> Feedbacks { get; set; }
    //public ICollection<Notification> Notifications { get; set; }
}
