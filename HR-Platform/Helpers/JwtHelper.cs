using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AdAstra.HRPlatform.API.Helpers
{
    public static class JwtHelper
    {
        public static SymmetricSecurityKey GetSymmetricSecurityKey(string key)
        {
            return new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key));
        }
    }
}