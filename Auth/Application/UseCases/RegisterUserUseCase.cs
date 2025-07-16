using Auth.Application.Interfaces;
using Auth.Infrastructure;
using Auth.Domain;
using OrderSharedContent;
using OrderSharedContent.Context;

namespace Auth.Application.UseCases
{
    public class RegisterUserUseCase
    {
        private readonly AuthContext _context;
        private readonly IPasswordHasher _passwordHasher;
        public RegisterUserUseCase(AuthContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public bool Execute(RegisterRequest rr)
        {
            if (rr.Password != rr.ConfirmPassword)
                throw new Exception("Password and confirm password don't match!");

            var user = _context.Users.FirstOrDefault(u => u.UserName == rr.Username);
            if (user != null)
                throw new Exception("Username is already taken!");

            var hashedPassword = _passwordHasher.HashPassword(rr.Password);
            var newUser = new User(rr.Username, rr.Email, hashedPassword);
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return true;
        }
    }
} 