using Backend.Package.Entities;

namespace Backend.Persistence
{
    public interface IUserRepository
    {
        void Migrate();

        User GetUser(string username);

        User GetUser(Guid id);

        User GetProfile(string username);

        IEnumerable<User> GetUsers();

        bool UserExists(string username);

        void SaveUser(User user);

        void AddContact(string receiver, Guid giver, IEnumerable<string> associatedContacts);

        IEnumerable<DirectContact> GetContacts(Guid id);
    }
}
