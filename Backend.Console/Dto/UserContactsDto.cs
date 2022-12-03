using Backend.Package.Entities;

namespace Backend.Console.Dto
{
    public class UserContactDto
    {
        public User Profile { get; set; }

        public IEnumerable<User> AssociatedProfiles { get; set; }
    }
}
