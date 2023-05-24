using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AdAstra.HRPlatform.Entities;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace AdAstra.HRPlatform.Helpers
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