using AdAstra.HRPlatform.API.Entities;
using System.Security.Claims;

namespace AdAstra.HRPlatform.API.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}