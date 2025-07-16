using Auth.Application.Interfaces;
using Auth.Infrastructure;
using Auth.Domain;
using OrderSharedContent;
using OrderSharedContent.Context;
using System.Security.Claims;

namespace Auth.Application.UseCases
{
    public class LoginUserUseCase
    {
        private readonly AuthContext _context;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher _passwordHasher;
        public LoginUserUseCase(AuthContext context, ITokenService tokenService, IPasswordHasher passwordHasher)
        {
            _context = context;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public string Execute(LoginRequest lr)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == lr.Username);

            if (user == null)
            {
                throw new Exception("User is not found!");
            }

            bool verifyHashPass = _passwordHasher.VerifyPassword(lr.Password, user.PasswordHash);

            if (!verifyHashPass)
            {
                throw new Exception("Incorrect credentials!");
            }

            var claims = new[] { new Claim(ClaimTypes.Name, lr.Username) };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            Session.Username = lr.Username;

            _context.SaveChanges();

            return accessToken;
        }
    }
} 