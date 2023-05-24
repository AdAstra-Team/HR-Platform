using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdAstra.HRPlatform.Helpers;
using AdAstra.HRPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using AdAstra.HRPlatform.Entities;
using AdAstra.HRPlatform.Services.Interfaces;

namespace AdAstra.HRPlatform.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(AuthenticateResponse), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            var response = await _userService.Register(userModel);

            if (response == null)
            {
                return BadRequest(new {message = "Didn't register!"});
            }

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("me")]
        [ProducesResponseType(typeof(UserModel), 200)]
        [ProducesResponseType(typeof(NotFoundObjectResult), 404)]
        public IActionResult GetMe()
        {
            var user = _userService.GetAll()
                .FirstOrDefault(u => u.Username == User.Identity?.Name);
            if (user == null)
            {
                return NotFound("User is not found");
            }
            return Ok(user);
        }
    }
}
