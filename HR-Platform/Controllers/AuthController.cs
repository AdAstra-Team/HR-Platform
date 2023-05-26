﻿using AdAstra.HRPlatform.Domain.Models;
using AdAstra.HRPlatform.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AdAstra.HRPlatform.Domain.Exceptions;

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
            AuthenticateResponse? response;
            try
            {
                response = _userService.UpdateToken(model);

                if (response == null)
                {
                    return BadRequest(new { message = "Username or password is incorrect" });
                }
            } catch (ServiceLayerException ex)
            {
                // TODO: add logger
                return BadRequest(ex);
            }

            return Ok(response);
        }
    }
}
