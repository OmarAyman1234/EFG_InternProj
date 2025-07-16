namespace Auth.Domain
{
    public class User
    {
        public User() { }
        public User(string username, string email, string passwordHash)
        {
            UserName = username;
            Email = email;
            PasswordHash = passwordHash;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
