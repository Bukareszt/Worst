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
        public UserDto GetProfile(GetProfileDto request)
        {
            logger.LogInformation("Getting profile of user {Username}", request.Username);

            var user = profileService.GetProfile(request.Username);

            return new UserDto
            {
                Username = user.Username,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email
            };
        }
    }
}
