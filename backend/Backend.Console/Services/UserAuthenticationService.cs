using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using Backend.Package.Entities;
using Backend.Persistence;
using Backend.Console.Dto;

namespace Backend.Console.Services
{
    public class UserAuthenticationService
    {
        private readonly ILogger<UserAuthenticationService> logger;
        private readonly IUserRepository repository;
        private readonly PasswordHasher<User> passwordHasher;

        public UserAuthenticationService(IUserRepository repository, ILogger<UserAuthenticationService> logger)
        {
            this.repository = repository;
            this.logger = logger;
            passwordHasher = new PasswordHasher<User>();
        }

        public void Register(UserRegistrationDto registration)
        {
            var userExists = repository.UserExists(registration.Username);
            if(userExists){
              throw new InvalidOperationException($"User with name {registration.Username} already exists");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = registration.Username,
            };

            user.PasswordHash = GetPasswordHash(user, registration.Password);

            repository.SaveUser(user);
        }

        public string GetPasswordHash(User user, string password)
        {
            return passwordHasher.HashPassword(user, password);
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return repository.GetUsers().Select(u => new UserDto { Username = u.Username });
        }
    }
}
