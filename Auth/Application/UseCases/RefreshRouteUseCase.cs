using Auth.Domain;
using Auth.Application.Interfaces;
using Auth.Infrastructure;
using OrderSharedContent.Context;
using System.Security.Claims;

namespace Auth.Application.UseCases
{
    public class RefreshRouteUseCase
    {
        private readonly AuthContext _context;
        private readonly ITokenService _tokenService;
        public RefreshRouteUseCase(AuthContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public string Execute()
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
                Session.Username = string.Empty;
                Session.Token = string.Empty;
                throw new Exception("You need to login!");
            }
        }
    }
} 