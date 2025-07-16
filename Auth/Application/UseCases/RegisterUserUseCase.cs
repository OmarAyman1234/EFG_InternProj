using Auth.Application.Interfaces;
using Auth.Domain;
using OrderSharedContent;

namespace Auth.Application.UseCases
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        public RegisterUserUseCase(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public bool Execute(RegisterRequest rr)
        {
            if (rr.Password != rr.ConfirmPassword)
                throw new Exception("Password and confirm password don't match!");

            var user = _userRepository.GetByUserName(rr.Username);
            if (user != null)
                throw new Exception("Username is already taken!");

            var hashedPassword = _passwordHasher.HashPassword(rr.Password);
            var newUser = new User(rr.Username, rr.Email, hashedPassword);
            _userRepository.Add(newUser);
            _userRepository.SaveChanges();
            return true;
        }
    }
} 