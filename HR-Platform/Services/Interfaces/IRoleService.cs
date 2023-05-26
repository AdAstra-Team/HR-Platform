using AdAstra.HRPlatform.API.Entities;

namespace AdAstra.HRPlatform.API.Services.Interfaces
{
    public interface IRoleService
    {
        User AssignRole(User user, string role);
    }
}