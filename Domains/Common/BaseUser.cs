namespace Branwise.Domains.Common;

public abstract class BaseUser : BaseClass
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }
}
