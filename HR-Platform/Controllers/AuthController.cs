using AdAstra.HRPlatform.API.Models;
using AdAstra.HRPlatform.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdAstra.HRPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(response);
        }

        [HttpPost("refresh")]
        public IActionResult Refresh(TokensModel model)
        {
            var response = _userService.UpdateToken(model);

            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(response);
        }
    }
}
