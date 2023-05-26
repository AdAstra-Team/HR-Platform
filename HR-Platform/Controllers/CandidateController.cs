using AdAstra.HRPlatform.Domain.Models;
using AdAstra.HRPlatform.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdAstra.HRPlatform.API.Controllers
{
    public class CandidateController
    {
        private readonly IUserService _userService;

        public CandidateController(IUserService userService)
        {
            _userService = userService;
        }

    }
}
