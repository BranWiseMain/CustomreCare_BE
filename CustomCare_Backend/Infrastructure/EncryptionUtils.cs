namespace Branwise.Infrastructure;

public static class EncryptionUtils
{
    // For passwords
    public static string HashPassword(string password) =>
        BCrypt.Net.BCrypt.HashPassword(password);

    public static bool VerifyPassword(string password, string hashedPassword) =>
        BCrypt.Net.BCrypt.Verify(password, hashedPassword);

    // For API keys
    public static string HashApiKey(string apiKey) =>
        BCrypt.Net.BCrypt.HashPassword(apiKey);

    public static bool VerifyApiKey(string apiKey, string hashedApiKey) =>
        BCrypt.Net.BCrypt.Verify(apiKey, hashedApiKey);
}
