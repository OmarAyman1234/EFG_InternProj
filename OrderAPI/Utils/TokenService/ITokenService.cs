using System.Security.Claims;

namespace OrderAPI.Utils.TokenService
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
    }
}
