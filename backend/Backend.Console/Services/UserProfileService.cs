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

        public User GetProfile(Guid id)
        {
            return repository.GetUser(id);
        }

        public IEnumerable<UserContactDto> GetContacts(Guid id)
        {
          return repository.GetContacts(id);
        }
    }
}
