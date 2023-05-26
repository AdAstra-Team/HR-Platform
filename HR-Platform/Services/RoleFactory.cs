using AdAstra.HRPlatform.API.Entities;
using AdAstra.HRPlatform.API.Entities.Base;
using AdAstra.HRPlatform.API.Entities.Roles;
using AdAstra.HRPlatform.API.Exceptions;
using AdAstra.HRPlatform.API.Services.Interfaces;

namespace AdAstra.HRPlatform.API.Services
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
