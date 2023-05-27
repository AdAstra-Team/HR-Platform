using AdAstra.HRPlatform.Domain.Entities;
using AdAstra.HRPlatform.Domain.Interfaces;

namespace AdAstra.HRPlatform.API.Services.Users
{
    public class RoleService : IRoleService
    {
        private readonly IRoleFactory _roleFactory;
        private readonly IEfRepository<User> _userRepository;
        private readonly IEfRepository<UserRole> _userRoleRepository;
        private readonly string[] roles = new string[] {
            "hrbp",
            "hrmanager",
            "employer"
        };

        public RoleService(IRoleFactory roleFactory,
                           IEfRepository<User> userRepository,
                           IEfRepository<UserRole> userRoleRepository)
        {
            _roleFactory = roleFactory;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public string[] Roles => roles;

        public User AssignRoleAndAdd(User user, string role)
        {
            var createdRole = _roleFactory.Create(role);
            var userRole = new UserRole
            {
                User = user,
                Role = createdRole
            };
            _userRoleRepository.Add(userRole);
            return _userRepository.GetById(user.Id);
        }

        public bool ValidateRole(string role)
        {
            return roles.Contains(role.ToLower());
        }
    }
}
