using Auth.Application.Interfaces;
using OrderSharedContent.Context;
using System.Security.Claims;

namespace Auth.Application.UseCases
{
    public class RefreshRouteUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        public RefreshRouteUseCase(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public string Execute()
        {
            var user = _userRepository.GetByUserName(Session.Username);

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