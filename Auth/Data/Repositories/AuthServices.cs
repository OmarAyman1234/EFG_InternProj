using Auth.Models;
using Auth.Utils.TokenService;
using Auth.Data.Context;
using OrderSharedContent;
using OrderSharedContent.Context;
using System.Security.Claims;

namespace Auth.Data.Repositories
{
    public class AuthServices : IAuthServices
    {
        private readonly AuthContext _context;
        private readonly ITokenService _tokenService;
        public AuthServices(AuthContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public string LoginUser(LoginRequest lr)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == lr.Username);

            if (user == null)
            {
                throw new Exception("User is not found!");
            }

            bool verifyHashPass = BCrypt.Net.BCrypt.Verify(lr.Password, user.PasswordHash);

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
        public bool RegisterUser(RegisterRequest rr)
        {
            if (rr.Password != rr.ConfirmPassword)
                throw new Exception("Password and confirm password don't match!");

            var user = _context.Users.FirstOrDefault(u => u.UserName == rr.Username);
            if (user != null)
                throw new Exception("Username is already taken!");

            var newUser = new User(rr.Username, rr.Email, rr.Password);
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return true;
        }
        public string Refresh()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == Session.Username);

            if(user == null)
            {
                throw new Exception("You need to login!");
            }

            if(DateTime.UtcNow <= user.RefreshTokenExpiryTime)
            {
                var claims = new[] { new Claim(ClaimTypes.Name, Session.Username) };
                string accessToken = _tokenService.GenerateAccessToken(claims);
                Session.Token = accessToken;
                return accessToken;
            }
            else
            {
                Session.Username = String.Empty;
                Session.Token = String.Empty;
                throw new Exception("You need to login!");
            }
        }
    }
}
