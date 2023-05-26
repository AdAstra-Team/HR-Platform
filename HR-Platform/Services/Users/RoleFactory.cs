using AdAstra.HRPlatform.Domain.Entities.Base;
using AdAstra.HRPlatform.Domain.Entities.Roles;
using AdAstra.HRPlatform.Domain.Exceptions;
using AdAstra.HRPlatform.Domain.Interfaces;

namespace AdAstra.HRPlatform.API.Services.Users
{
    public class RoleFactory : IRoleFactory
    {
        public Role Create(string role, params object[] args)
        {
            return role switch
            {
                "HRManager" => new HRManagerRole(),
                "Hrbr" => new HrbrRole(),
                "Employer" => new EmployerRole(),
                _ => throw new ServiceLayerException("Role not found")
            };
        }
    }
}
