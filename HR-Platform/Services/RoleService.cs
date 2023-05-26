﻿using AdAstra.HRPlatform.API.Entities;
using AdAstra.HRPlatform.API.Services.Interfaces;

namespace AdAstra.HRPlatform.API.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleFactory _roleFactory;
        private readonly IEfRepository<User> _userRepository;
        private readonly IEfRepository<UserRole> _userRoleRepository;

        public RoleService(IRoleFactory roleFactory,
                           IEfRepository<User> userRepository,
                           IEfRepository<UserRole> userRoleRepository)
        {
            _roleFactory = roleFactory;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public User AssignRole(User user, string role)
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
    }
}
