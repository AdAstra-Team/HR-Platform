using AdAstra.HRPlatform.Domain.Interfaces;
using AdAstra.HRPlatform.API.Services.Users;
using AdAstra.HRPlatform.Domain.Interfaces;
using System.Runtime.CompilerServices;

namespace AdAstra.HRPlatform.API.Services.Injection
{
    public static class ServicesInjection
    {
        public static void AddMainServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleFactory, RoleFactory>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPasswordHashingService, PasswordHashingService>();
        }
    }
}
