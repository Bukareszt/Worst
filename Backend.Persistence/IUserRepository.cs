using Backend.Package.Entities;

namespace Backend.Persistence
{
    public interface IUserRepository
    {
        void Migrate();

        User GetUser(string username);

        User GetUser(Guid id);

        IEnumerable<User> GetUsers();

        bool UserExists(string username);

        void SaveUser(User user);

        IEnumerable<DirectContact> GetContacts(Guid id);
    }
}
