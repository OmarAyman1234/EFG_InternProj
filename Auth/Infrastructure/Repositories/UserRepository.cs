using Auth.Application.Interfaces;
using Auth.Domain;

namespace Auth.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthContext _context;
        public UserRepository(AuthContext context)
        {
            _context = context;
        }

        public User GetByUserName(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
} 