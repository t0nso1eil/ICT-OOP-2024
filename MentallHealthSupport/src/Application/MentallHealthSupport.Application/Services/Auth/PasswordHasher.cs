namespace MentallHealthSupport.Application.Services.Auth;

public class PasswordHasher
{
    public string GenerateHash(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string password, string passwordHash) => BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
}