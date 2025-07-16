using Auth.Application.Interfaces;

namespace Auth.Infrastructure.PasswordHashing
{
    public class BCryptPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        public bool VerifyPassword(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);
    }
} 