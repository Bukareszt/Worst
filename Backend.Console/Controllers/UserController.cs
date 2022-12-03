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
        [Route("all")]
        public IEnumerable<User> GetAll([FromQuery] string username)
        {
            logger.LogInformation("Getting profile of user {Username}", username);

            var user = profileService.GetProfile(username);
            return user.Contacts;
        }

        [HttpGet]
        public User Get([FromQuery] string username)
        {
            logger.LogInformation("Getting profile of user {Username}", username);

            var user = profileService.GetProfile(username);
            return user;
        }

        [HttpPost]
        public IActionResult CreateUser()
        {
            return StatusCode(200);
        }

        [HttpPut]
        public IActionResult UpdateUser()
        {
            return StatusCode(200);

        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return StatusCode(200);
        }
    }
}
