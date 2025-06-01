namespace Branwise.Domains.Entites;

public class Provider
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LogoUrl { get; set; }


    public ICollection<User> User { get; set; }
    public ICollection<IssueReport> IssueReports { get; set; }

}
