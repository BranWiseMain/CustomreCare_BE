using Branwise.Domains.Enums;

namespace Branwise.Domains.Entites;

public class FeedBack
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
    public SenderType Sender { get; set; }
    public User User { get; set; }
}
