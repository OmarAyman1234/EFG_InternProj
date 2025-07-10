namespace OrderAPI.Models
{
    public class User
    {
        public User() { }
        public User(string username, string email, string password)
        {
            UserName = username;
            Email = email;
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
