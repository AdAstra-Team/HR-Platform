using AdAstra.HRPlatform.API.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace AdAstra.HRPlatform.API.Services.Injection
{
    public static class ServicesInjection
    {
        public static void AddMainServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPasswordHashingService, PasswordHashingService>();
        }
    }
}
