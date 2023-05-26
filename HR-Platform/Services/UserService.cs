using AdAstra.HRPlatform.API.Entities;
using AdAstra.HRPlatform.API.Entities.Base;
using AdAstra.HRPlatform.API.Exceptions;
using AdAstra.HRPlatform.API.Helpers;
using AdAstra.HRPlatform.API.Models;
using AdAstra.HRPlatform.API.Services.Interfaces;
using AutoMapper;

namespace AdAstra.HRPlatform.API.Services
{
    public class UserService : IUserService
    {
        private readonly IEfRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public UserService(IEfRepository<User> userRepository,
                           IConfiguration configuration,
                           IMapper mapper,
                           ITokenService tokenService,
                           IPasswordHashingService passwordHashingService,
                           IRoleService roleService)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
            _tokenService = tokenService;
            _passwordHashingService = passwordHashingService;
            _roleService = roleService;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userRepository
                .GetAll()
                .FirstOrDefault(x => x.Username == model.Username &&
                                     _passwordHashingService.VerifyPassword(model.Password, x.Password));

            if (user == null)
            {
                // TODO: need to add logger
                return null;
            }

            var token = _tokenService.GenerateAccessToken(user);
            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7).ToUniversalTime();
            _userRepository.Update(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task<AuthenticateResponse> Register(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);

            var password = user.Password;
            user.Password = _passwordHashingService.HashPassword(password);

            if (!ValidationHelper.ValidateUnique(user, _userRepository, u => u.Username))
            {
                throw new ServiceLayerException($"User with username '{user.Username}' is alreay registered.");
            }

            if (!ValidationHelper.ValidateUnique(user, _userRepository, u => u.Email))
            {
                throw new ServiceLayerException($"User with email '{user.Email}' is alreay registered.");
            }


            var addedUser = _userRepository.Add(user);
            _roleService.AssignRole(user, userModel.Role);

            var response = Authenticate(new AuthenticateRequest
            {
                Username = user.Username,
                Password = password
            });
            
            return response;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public AuthenticateResponse UpdateToken(TokensModel model)
        {
            string accessToken = model.AccessToken;
            string refreshToken = model.RefreshToken;
            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity?.Name; //this is mapped to the Name claim by default
            var user = _userRepository.GetAll().SingleOrDefault(u => u.Username == username);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new ServiceLayerException("Invalid client request");
            }
            var newAccessToken = _tokenService.GenerateAccessToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7).ToUniversalTime();
            _userRepository.Update(user);
            return new AuthenticateResponse(user, newAccessToken);
        }
    }
}