using AdAstra.HRPlatform.API.Entities.Base;

namespace AdAstra.HRPlatform.API.Services.Interfaces
{
    public interface IRoleFactory
    {
        Role Create(string role, params object[] args);
    }
}