namespace Branwise.Infrastructure;

public class Encrptions
{
    public static string Hashpassowrd(string passowrd)
    {
        return BCrypt.Net.BCrypt.HashPassword(passowrd);
    }
    public static bool VerifyPassword(string passowrd, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(passowrd, hashedPassword);
    }
}
