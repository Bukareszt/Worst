using Microsoft.AspNetCore.Mvc;
using Backend.Console.Services;
using Backend.Package.Entities;
using Backend.Console.Dto;

namespace Backend.Console
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly UserProfileService profileService;

        public UserController(UserProfileService profileService, ILogger<UserController> logger)
        {
            this.logger = logger;
            this.profileService = profileService;
        }

        [HttpGet]
        [Route("{username}")]
        public User GetProfile(string username)
        {
            logger.LogInformation("Getting profile of user {Username}", username);

            var user = profileService.GetProfile(username);
            return user;
        }
    }
}
