using Auth.Domain;

namespace Auth.Application.Interfaces
{
    public interface IUserRepository
    {
        User GetByUserName(string username);
        void Add(User user);
        void SaveChanges();
    }
} 