using Backend.Persistence;
using Backend.Console.Dto;
using Backend.Package.Entities;

namespace Backend.Console.Services
{
    public class UserProfileService
    {
        private readonly IUserRepository repository;

        public UserProfileService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public User GetProfile(string Username)
        {
            return repository.GetUser(Username);
        }
    }
}
