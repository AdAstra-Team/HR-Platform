using AdAstra.HRPlatform.Entities;
using System.Security.Claims;

namespace AdAstra.HRPlatform.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}