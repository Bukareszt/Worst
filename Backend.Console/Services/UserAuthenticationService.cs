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
            if (userExists)
            {
                throw new InvalidOperationException($"User with name {registration.Username} already exists");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = registration.Username,
                Name = registration.Name,
                Email = registration.Email,
                Surname = registration.Surname,
            };

            user.PasswordHash = GetPasswordHash(user, registration.Password);

            repository.SaveUser(user);
        }

        public bool Login(UserLoginDto login)
        {
            var user = repository.GetUser(login.Username);
            if (user is null)
            {
                throw new InvalidOperationException($"User with username {login.Username} doesn't exist");
            }
            var authResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, login.Password);
            return authResult == PasswordVerificationResult.Success;
        }

        public string GetPasswordHash(User user, string password)
        {
            return passwordHasher.HashPassword(user, password);
        }
    }
}
