using Microsoft.AspNetCore.Mvc;
using Backend.Console.Services;
using Backend.Package.Entities;
using Backend.Console.Queries;
using Backend.Console.Dto;

namespace Backend.Console
{
    [ApiController]
    [Route("auth")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly UserProfileService profileService;

        public UserController(UserProfileService profileService, ILogger<UserController> logger)
        {
            this.logger = logger;
            this.profileService = profileService;
        }

        [HttpPost]
        [Route("get-profile")]
        public User GetProfile(GetProfileQuery request)
        {
            logger.LogInformation("Getting profile of user {Id}", request.Id);
            return profileService.GetProfile(request.Id);
        }

        [HttpPost]
        [Route("get-contacts")]
        public void GetContacts(GetContactsQuery request)
        {
            logger.LogInformation("Geting contacts of user {Id}", request.Id);
            //return p;
        }
    }
}
