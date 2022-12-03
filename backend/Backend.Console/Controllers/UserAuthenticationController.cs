using Microsoft.AspNetCore.Mvc;
using Backend.Console.Services;
using Backend.Console.Dto;

namespace Backend.Console
{
    [ApiController]
    [Route("auth")]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly ILogger<UserAuthenticationController> logger;
        private readonly UserAuthenticationService authenticationService;

        public UserAuthenticationController(UserAuthenticationService authenticationService, ILogger<UserAuthenticationController> logger)
        {
            this.logger = logger;
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("register")]
        public void Register(UserRegistrationDto registration)
        {
            logger.LogInformation("Registering user: {Username}", registration.Username);
            authenticationService.Register(registration);
        }

        [HttpPost]
        [Route("login")]
        public bool Login(UserLoginDto login)
        {
            logger.LogInformation("Logging user: {Username}", login.Username);
            return authenticationService.Login(login);
        }
    }
}
